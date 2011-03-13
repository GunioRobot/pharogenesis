newPageForStandardPartsBin
	| aPage |
	aPage _ PasteUpMorph new.
	aPage color: Color white; padding: 10.
	aPage autoLineLayout: true.
	aPage isPartsBin: true; openToDragNDrop: false.
	^ aPage