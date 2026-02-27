const GRID_SIZE = 10;
const SHIP_RULES = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

let playerBoard = [], enemyBoard = [];
let isVertical = false;
let currentShipIndex = 0;
let gameState = 'placement'; 

function init() {
    createBoard('player-board', playerBoard, true);
    createBoard('enemy-board', enemyBoard, false);
    
    document.getElementById('rotate-btn').onclick = () => {
        isVertical = !isVertical;
        document.getElementById('rotate-btn').innerText = isVertical ? "ВЕРТИКАЛЬНО" : "ГОРИЗОНТАЛЬНО";
    };

    document.getElementById('auto-btn').onclick = autoPlacePlayerShips;
    document.getElementById('start-btn').onclick = startBattle;
    document.getElementById('reset-btn').onclick = () => location.reload();
    
    placeShipsRandomly(enemyBoard);
}

function createBoard(id, boardArr, isPlayer) {
    const el = document.getElementById(id);
    for (let r = 0; r < GRID_SIZE; r++) {
        boardArr[r] = [];
        for (let c = 0; c < GRID_SIZE; c++) {
            const cell = document.createElement('div');
            cell.className = 'cell';
            cell.onclick = () => handleCellClick(r, c, isPlayer);
            el.appendChild(cell);
            boardArr[r][c] = { hasShip: false, hit: false, el: cell };
        }
    }
}

function handleCellClick(r, c, isPlayer) {
    if (gameState === 'placement' && isPlayer) {
        placePlayerShip(r, c);
    } else if (gameState === 'battle' && !isPlayer) {
        handlePlayerShot(r, c);
    }
}

function placePlayerShip(r, c) {
    if (currentShipIndex >= SHIP_RULES.length) return;
    const len = SHIP_RULES[currentShipIndex];
    if (canPlace(playerBoard, r, c, len, isVertical)) {
        applyPlacement(playerBoard, r, c, len, isVertical, true);
        currentShipIndex++;
        updatePlacementStatus();
    }
}

function autoPlacePlayerShips() {
    // Сброс текущей расстановки перед авто-заполнением
    playerBoard.flat().forEach(cell => {
        cell.hasShip = false;
        cell.el.classList.remove('ship');
    });
    
    placeShipsRandomly(playerBoard, true);
    currentShipIndex = SHIP_RULES.length;
    updatePlacementStatus();
}

function updatePlacementStatus() {
    if (currentShipIndex >= SHIP_RULES.length) {
        gameState = 'ready';
        document.getElementById('status').innerText = "Флот готов к бою!";
        document.getElementById('start-btn').disabled = false;
        document.getElementById('auto-btn').innerText = "ПЕРЕМЕШАТЬ";
    } else {
        document.getElementById('status').innerText = `Установите корабль (${SHIP_RULES[currentShipIndex]} палубы)`;
    }
}

function applyPlacement(board, r, c, len, vert, show) {
    for (let i = 0; i < len; i++) {
        let curR = vert ? r + i : r;
        let curC = vert ? c : c + i;
        board[curR][curC].hasShip = true;
        if (show) board[curR][curC].el.classList.add('ship');
    }
}

function canPlace(board, r, c, len, vert) {
    if (vert && r + len > GRID_SIZE) return false;
    if (!vert && c + len > GRID_SIZE) return false;
    for (let i = -1; i <= len; i++) {
        for (let j = -1; j <= 1; j++) {
            let curR = vert ? r + i : r + j;
            let curC = vert ? c + j : c + i;
            if (curR >= 0 && curR < GRID_SIZE && curC >= 0 && curC < GRID_SIZE) {
                if (board[curR][curC].hasShip) return false;
            }
        }
    }
    return true;
}

function placeShipsRandomly(board, show = false) {
    SHIP_RULES.forEach(len => {
        let placed = false;
        while (!placed) {
            let v = Math.random() > 0.5;
            let r = Math.floor(Math.random() * GRID_SIZE);
            let c = Math.floor(Math.random() * GRID_SIZE);
            if (canPlace(board, r, c, len, v)) {
                applyPlacement(board, r, c, len, v, show);
                placed = true;
            }
        }
    });
}

function startBattle() {
    gameState = 'battle';
    document.getElementById('enemy-board').classList.remove('blur');
    document.getElementById('start-btn').disabled = true;
    document.getElementById('auto-btn').disabled = true;
    document.getElementById('rotate-btn').disabled = true;
    document.getElementById('status').innerText = "ВАШ ХОД";
}

function handlePlayerShot(r, c) {
    if (enemyBoard[r][c].hit || gameState !== 'battle') return;
    const hit = shoot(enemyBoard, r, c);
    if (!hit) {
        gameState = 'bot_turn';
        document.getElementById('status').innerText = "ХОД ВРАГА";
        setTimeout(botTurn, 1000);
    } else {
        checkWinner();
    }
}

function botTurn() {
    let r, c;
    do {
        r = Math.floor(Math.random() * GRID_SIZE);
        c = Math.floor(Math.random() * GRID_SIZE);
    } while (playerBoard[r][c].hit);

    const hit = shoot(playerBoard, r, c);
    if (hit) {
        if (!checkWinner()) setTimeout(botTurn, 1000);
    } else {
        gameState = 'battle';
        document.getElementById('status').innerText = "ВАШ ХОД";
    }
}

function shoot(board, r, c) {
    board[r][c].hit = true;
    if (board[r][c].hasShip) {
        board[r][c].el.classList.add('hit');
        return true;
    }
    board[r][c].el.classList.add('miss');
    return false;
}

function checkWinner() {
    const pLost = playerBoard.flat().every(c => !c.hasShip || c.hit);
    const eLost = enemyBoard.flat().every(c => !c.hasShip || c.hit);
    if (pLost || eLost) {
        gameState = 'over';
        document.getElementById('status').innerText = pLost ? "ВЫ ПРОИГРАЛИ!" : "ПОБЕДА!";
        return true;
    }
    return false;
}

init();