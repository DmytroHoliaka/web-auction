let pageFromLocalStorage = {};

pageFromLocalStorage.updatePhotos = () => {
    let photosBlock = document.querySelector('.auctionPhotos');

    let thumbnailsBlock = photosBlock.firstElementChild;
    let currentPhotoImage = photosBlock.lastElementChild.firstElementChild;

    let photos = JSON.parse(localStorage.getItem('photos'));

    currentPhotoImage.setAttribute('src',
        photos[0]
    )
    thumbnailsBlock.innerHTML = '';
    for (let photoSrc of photos) {
        let photo = document.createElement('img');
        photo.setAttribute('src', photoSrc);
        thumbnailsBlock.appendChild(photo);
    }
    thumbnailsBlock.firstElementChild.setAttribute('class', 'currentPhotoThumbnail');
}

pageFromLocalStorage.getCurrentPhotoIndex = () => {
    let thumbnailsBlock = document.querySelector('.thumbnails');
    let curThumbnailIndex = 0;
    let curElement = thumbnailsBlock.firstElementChild;
    while (curThumbnailIndex < thumbnailsBlock.childElementCount) {
        if (curElement.getAttribute('class')) {
            console.log('Chosen thumb:', curThumbnailIndex);
            break;
        }
        curElement = curElement.nextElementSibling;
        curThumbnailIndex++;
    }
    return curThumbnailIndex;
}

export { pageFromLocalStorage }