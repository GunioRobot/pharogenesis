newPartsFlapPage
	| aPage |
	aPage _ PasteUpMorph new borderWidth: 0.
	aPage color: Color white; padding: 6.
	aPage autoLineLayout: true.
	aPage isPartsBin: true.
	aPage setProperty: #alwaysShowThumbnail toValue: true.
	^ aPage