// Script will run when the document (website) is loaded
document.addEventListener("DOMContentLoaded", StartGame);

// Score value
let score = 0;
// Time playing the game
let time = 0;
// ID process time measurement
let timerId = 0;

// Run timer
function StartTimer() {
    timerId = setInterval(UpdateTimer, 1000)
}

// Update timer
function UpdateTimer() {
    time++;
    let timerText = "";
    if (time < 60)
        timerText += "0:";
    else
        timerText += Math.floor(time / 60) + ":";
    if (time % 60 > 9)
        timerText += (time % 60);
    else
        timerText += "0" + (time % 60);
    document.getElementById("timer").innerHTML = timerText;
}

// Stop timer
function StopTimer() {
    clearInterval(timerId);
}

function StartGame() {
    // Start counting time after 2 seconds
    setTimeout(StartTimer, 2000);
    // Reference to game grid
    const gameGrid = document.getElementById("grid-container");
    // Reference to score panel
    const scoreDiv = document.getElementById("score-title");

    // Array of references to square objects
    const squares = [];
    // Game board size
    const size = 4;
    // Maximum number of tries for generating next number
    const triesLimit = 20;

    // Score prefix
    const scoreText = "Score: ";

    // Change square value and style depending on value
    function updateSquare(square, newValue) {
        square.innerHTML = newValue;
        // Change square color
        switch (newValue) {
            case 0:
                square.style.backgroundColor = "#800000";
                square.innerHTML = "";
                break;
            case 2:
                square.style.backgroundColor = "#e60d00";
                break;
            case 4:
                square.style.backgroundColor = "#ff5500";
                break;
            case 8:
                square.style.backgroundColor = "#ff7600";
                break;
            case 16:
                square.style.backgroundColor = "goldenrod";
                break;
            case 32:
                square.style.backgroundColor = "#ffcc00";
                break;
            case 64:
                square.style.backgroundColor = "#ace600";
                break;
            case 128:
                square.style.backgroundColor = "#739900";
                break;
            case 256:
                square.style.backgroundColor = "#0099cc";
                break;
            case 512:
                square.style.backgroundColor = "#cc00ff";
                break;
            case 1024:
                square.style.backgroundColor = "#4d0000";
                break;
            //2048 and higher values
            default:
                square.style.backgroundColor = "#000000";
                break;
        }
    }

    // Adds scoreChange to current score and displays new value
    function updateScore(scoreChange) {
        // Change score if it is not empty
        if (!isNaN(scoreChange)) {
            score += scoreChange;
            scoreDiv.innerHTML = scoreText + score;
        }
    }

    // Generate a new random number
    function generate(tries) {
        // Random place in grid
        const randomNumber = Math.floor(Math.random() * squares.length);
        // Randomly get value 2(70% of the time) or 4 (30%)
        const random = Math.random() * 10;
        let value;
        if (random < 7)
            value = 2;
        else
            value = 4;
        // Check if square we want to place numbers is empty
        if (squares[randomNumber].innerHTML == "") {
            updateSquare(squares[randomNumber], value);
            checkForLose();
        }
        // If we reached maximum allowed tries (prevents infinite searching)
        else if (tries >= triesLimit) {
            for (let i = 0; i < size * size; i++) {
                if (squares[i].innerHTML == "") {
                    updateSquare(squares[i], value);
                    checkForLose();
                    console.log("Limit reached, square: " + i);
                }
            }
        }
        else {
            // Count number of tries, if too many just place number in first empty spot
            generate(tries++);
        }
    }

    // Creating board
    function createBoard() {
        for (let i = 0; i < size * size; i++) {
            // Create div with class square
            const square = document.createElement("div");
            square.className = "square";
            updateSquare(square, 0);
            gameGrid.appendChild(square);
            squares.push(square);
        }
        generate();
        generate();
    }
    createBoard();


    // Swipe right (true) or left (false)
    // Return false if no element was moved
    function moveHorizontal(right) {
        // Remember if any element was moved
        let moved = false;
        for (let i = 0; i < size * size; i += size) {
            let row = [parseInt(squares[i].innerHTML),
            parseInt(squares[i + 1].innerHTML),
            parseInt(squares[i + 2].innerHTML),
            parseInt(squares[i + 3].innerHTML)
            ];

            // Take only rows with values
            let filteredRow = row.filter(num => num);
            // Count how many 0's are needed
            let missing = size - filteredRow.length;
            let zeros = Array(missing).fill(0);
            // Create new row and add 0's at the right or left end
            let newRow;
            if (right)
                newRow = zeros.concat(filteredRow);
            else
                newRow = filteredRow.concat(zeros);

            // If any element is moved
            for (let i = 0; i < newRow.length; i++) {
                if (newRow[i] != row[i]) {
                    moved = true;
                    break;
                }
            }

            updateSquare(squares[i], newRow[0]);
            updateSquare(squares[i + 1], newRow[1]);
            updateSquare(squares[i + 2], newRow[2]);
            updateSquare(squares[i + 3], newRow[3]);
        }
        return moved;
    }

    // Swipe up (true) or left (false)
    // Return false if no element was moved
    function moveVertical(up) {
        // Remember if any element was moved
        let moved = false;
        for (let i = 0; i < size; i++) {
            let column = [parseInt(squares[i].innerHTML),
            parseInt(squares[i + size].innerHTML),
            parseInt(squares[i + 2 * size].innerHTML),
            parseInt(squares[i + 3 * size].innerHTML)
            ];

            // Take only rows with values
            let filteredColumn = column.filter(num => num);
            // Count how many 0's are needed
            let missing = size - filteredColumn.length;
            let zeros = Array(missing).fill(0);
            let newColumn;
            if (up)
                newColumn = filteredColumn.concat(zeros);
            else
                newColumn = zeros.concat(filteredColumn);

            // If any element is moved
            for (let i = 0; i < newColumn.length; i++) {
                if (newColumn[i] != column[i]) {
                    moved = true;
                    break;
                }
            }

            updateSquare(squares[i], newColumn[0]);
            updateSquare(squares[i + size], newColumn[1]);
            updateSquare(squares[i + 2 * size], newColumn[2]);
            updateSquare(squares[i + 3 * size], newColumn[3]);
        }
        return moved;
    }
    // Combine 2 numbers in one row if they're equal
    function combineRow() {
        // Condition -1 because we don't compare last row from last column
        for (let i = 0; i < size * size - 1; i++) {
            // Skip last column
            if (i % size === size - 1) {
                continue;
            }
            if (squares[i].innerHTML === squares[i + 1].innerHTML) {
                const combinedValue = parseInt(squares[i].innerHTML) + parseInt(squares[i + 1].innerHTML);
                updateSquare(squares[i], combinedValue);
                updateSquare(squares[i + 1], 0);
                updateScore(combinedValue);
            }
        }
        checkForWin();
    }

    // Combine 2 numbers in one column if they're equal
    function combineColumn() {
        // Condition -4 because we don't compare last row
        for (let i = 0; i < size * size - 4; i++) {
            if (squares[i].innerHTML === squares[i + size].innerHTML) {
                const combinedValue = parseInt(squares[i].innerHTML) + parseInt(squares[i + size].innerHTML);
                updateSquare(squares[i], combinedValue);
                updateSquare(squares[i + size], 0);
                updateScore(combinedValue);
            }
        }
        checkForWin();
    }

    // Assign keycodes to functions
    function control(e) {
        const code = e.keyCode;
        // User pressed arrow right or 'd'
        if (code === 39 || code === 68) {
            keyRight();
        }
        // User pressed arrow left or 'a'
        else if (code === 37 || code === 65) {
            keyLeft();
        }
        // User pressed arrow up or 'w'
        else if (code === 38 || code === 87) {
            keyUp();
        }
        // User pressed arrow down or 's'
        else if (code === 40 || code === 83) {
            keyDown();
        }
    }

    // Add listener for user input
    document.addEventListener("keyup", control);

    // When user wants to move board to the right
    function keyRight() {
        // Move right
        let movedFst = moveHorizontal(true);
        // Combine rows
        combineRow();
        let movedSnd = moveHorizontal(true);
        // Generate new number if any element was moved
        if (movedFst || movedSnd)
            generate(0);
    }
    // When user wants to move board to the left
    function keyLeft() {
        // Move left
        let movedFst = moveHorizontal(false);
        combineRow();
        let movedSnd = moveHorizontal(false);
        // Generate new number if any element was moved
        if (movedFst || movedSnd)
            generate(0);
    }
    // When user wants to move board up
    function keyUp() {
        // Move up
        let movedFst = moveVertical(true);
        combineColumn();
        let movedSnd = moveVertical(true);
        // Generate new number if any element was moved
        if (movedFst || movedSnd)
            generate(0);
    }
    // When user wants to move board down
    function keyDown() {
        // Move down
        let movedFst = moveVertical(false);
        combineColumn();
        let movedSnd = moveVertical(false);
        // Generate new number if any element was moved
        if (movedFst || movedSnd)
            generate(0);
    }

    // Check if there is number 2048
    function checkForWin() {
        for (let i = 0; i < squares.length; i++) {
            if (squares[i].innerHTML == 2048) {
                // Stop checking user input
                document.removeEventListener("keyup", control);
                alert("Congratulations! You Win!\nScore: " + score);
            }
        }
    }

    // Check lose conditions
    // if there are no zeros on the board(no empty space left) and if there are no moves
    function checkForLose() {
        let zerosCount = 0;
        for (let i = 0; i < squares.length; i++) {
            if (squares[i].innerHTML == 0) {
                zerosCount++;
            }
        }
        if (zerosCount === 0 && !possibleMoves()) {
            // Stop checking user input
            document.removeEventListener("keyup", control);
            StopTimer();
            alert("Congratulations! You Lost!\nScore: " + score);
        }
    }

    // Check if there is possible move
    function possibleMoves() {
        // Check in column
        for (let i = 0; i < size * size - 1; i++) {
            // Skip last column
            if (i % size === size - 1) {
                continue;
            }
            if (squares[i].innerHTML === squares[i + 1].innerHTML) {
                return true;
            }
        }
        // Check in row
        for (let i = 0; i < size * size - 4; i++) {
            if (squares[i].innerHTML === squares[i + size].innerHTML) {
                return true;
            }
        }
        return false;
    }
}

// Restart game after user pressed button
function ResetGame() {
    location.reload();
}
