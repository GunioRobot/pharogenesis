updateThumbnail
	| f |
	f _ formChoices at: currentIndex.
	formDisplayMorph 
		makeThumbnailFromForm: f.
