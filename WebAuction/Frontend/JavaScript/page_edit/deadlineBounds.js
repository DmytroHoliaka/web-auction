let now = new Date();
let tomorrow = new Date();
let inYear = new Date();

tomorrow.setDate(now.getDate() + 1);
inYear.setFullYear(tomorrow.getFullYear() + 1);

function toString(date){
    return date.toISOString().slice(0,10)
}

let deadlineInput = document.forms['editDeadline']['newDeadline'];
deadlineInput.value = toString(tomorrow);
deadlineInput.min = toString(tomorrow);
deadlineInput.max = toString(inYear);
