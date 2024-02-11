let bidFormInput = document.forms['bidForm']['bid'];
let tableFirstRow = document.querySelector('table#history .ht-money');
let biggestBidString;

if (tableFirstRow === null){
    biggestBidString = document.getElementById('startingBid').innerHTML;
}else{
    biggestBidString = tableFirstRow.innerHTML;
}
let biggestBidNum = parseInt(biggestBidString.match(/\d+/)?.shift());
bidFormInput.setAttribute('value', biggestBidNum+1);
bidFormInput.setAttribute('min', biggestBidNum+0.1);

const observer = new MutationObserver((mutationsList, observer) => {
    biggestBidString = mutationsList[0].target.innerHTML;
    biggestBidNum = parseInt(biggestBidString.match(/\d+/)?.shift());
    bidFormInput.setAttribute('value', biggestBidNum+1);
    bidFormInput.setAttribute('min', biggestBidNum+0.1);
});

observer.observe(tableFirstRow, {childList: true});