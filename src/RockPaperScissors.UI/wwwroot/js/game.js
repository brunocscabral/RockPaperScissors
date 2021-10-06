const gameContainer = document.querySelector('.gameContainer');
const against = document.querySelector('#against').value;
const player1 = gameContainer.querySelector('.player1');
const player2 = gameContainer.querySelector('.player2');
const lastResult = document.querySelector('#lastResult');
const moveP2LastId = document.querySelector('#moveP2LastId');

const play = (moveP1, moveP2) => {
    $.post(`/Game/Play`,
        { moveP1: moveP1, moveP2: moveP2, against: against },
        (data) => {
            increaseScore(data);
            reestartGame();
            setlastResult(data);
        }
    );
}

const increaseScore = function (data) {
    data = JSON.parse(data);
    if (data.win == "Draw") return;

    const player = data.win == "P1" ? player1 : player2;
    const score = player.querySelector('h2 span');

    score.textContent++;

    if (score.textContent == 3) {
        alert(`${data.win} win!!!`);
        window.location.href = '/';
    }
}

const reestartGame = function () {
    gameContainer.querySelectorAll('a').forEach(e => e.classList.remove("active"));
}

const setlastResult = function (data) {
    lastResult.textContent = `Last round: P1 choice: ${JSON.parse(data).moveP1} | P2 choice: ${JSON.parse(data).moveP2}`;
    moveP2LastId.value = JSON.parse(data).moveP2LastId;
}

gameContainer.addEventListener('click', function (e) {
    if ((e.srcElement.id.startsWith('p1-') && !player1.querySelector('.active')) ||
        (e.srcElement.id.startsWith('p2-') && !player2.querySelector('.active'))) {
        e.srcElement.classList.add("active");
    }

    const moveP1 = player1.querySelector('.active');
    const moveP2 = player2.querySelector('.active');

    if (moveP1 && moveP2) play(moveP1.id.slice(3), moveP2.id.slice(3));     
    else if (moveP1 && against != "Humain") play(moveP1.id.slice(3), moveP2LastId.value);

}, false);




