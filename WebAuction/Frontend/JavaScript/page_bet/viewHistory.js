let bidInfo = document.getElementsByClassName('bidInfo')[0];
let userBidClone = bidInfo.firstElementChild.cloneNode(true);
let viewHistoryBtn = document.getElementById('viewHistory');

function returnBack(){
    bidInfo.insertBefore(userBidClone, bidInfo.firstElementChild);
    viewHistoryBtn.firstElementChild.setAttribute('src', 'Icons/viewHistory.svg');
    viewHistoryBtn.onclick = viewHistoryClick;
}

function viewHistoryClick(){
    bidInfo.removeChild(bidInfo.firstElementChild);
    viewHistoryBtn.firstElementChild.setAttribute('src', 'Icons/back.svg');
    viewHistoryBtn.onclick = returnBack;
}

viewHistoryBtn.onclick = viewHistoryClick;