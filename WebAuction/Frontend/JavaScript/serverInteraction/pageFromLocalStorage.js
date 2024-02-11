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

export { pageFromLocalStorage }