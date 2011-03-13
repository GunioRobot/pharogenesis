addPageTwoControlsTo: aLayoutPage
	"Return a book with pages containing controls"
	| aWorld spacer button |
	aWorld _ associatedMorph world.
	spacer _ Morph new color: Color transparent; extent: 1@3.

	button _ SimpleButtonMorph new target: aWorld; borderColor: Color black.
	aLayoutPage color: Color transparent; borderWidth: 0; inset: 0.
	aLayoutPage hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5; centering: #center.

	"Commands sent to the Hand"
		button target: self primaryHand; color: (Color r: 1.0 g: 0.8 b: 0.6) lighter.
		#(  
			('Import Graphic...'			importImageFromDisk)
			('Grab Screen Area'		grabDrawingFromScreen)
			('Show Hiders'			showHiders)
												)
		do:
			[:pair |
				aLayoutPage addMorphBack: (button fullCopy label: pair first;	actionSelector: pair last).
				aLayoutPage addMorphBack: spacer fullCopy]