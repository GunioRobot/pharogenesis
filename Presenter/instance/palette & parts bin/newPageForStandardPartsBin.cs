newPageForStandardPartsBin
	| aPage |
	aPage _ PasteUpMorph new extent:  361@175.
	aPage color: Color white; padding: 6.
	aPage autoLineLayout: true.
	aPage isPartsBin: true; disableDragNDrop.
	aPage setProperty: #alwaysShowThumbnail toValue: true.
	^ aPage