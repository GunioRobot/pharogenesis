controlsBook
	"Return a book with pages containing controls"

	| book col |
	book _ BookMorph newSticky borderWidth: 2; setNameTo: 'Controls Book'.
	book  removeEverything; addKidsDressing.
	
	book insertPageLabel: nil
		morphs: (Array with: (col _ AlignmentMorph newColumn)).
	self addPageOneControlsTo: col.
	col addTransparentSpacerOfSize: (1 @ 12).
	Smalltalk at: #RecordingControlsMorph ifPresent: [:recorderClass |
		col addMorphBack: recorderClass new beSticky.
		col addTransparentSpacerOfSize: (1 @ 12)].
	self addToggleButtonsTo: col forPage: 1.

	book insertPageLabel: nil
		morphs: (Array with: (col _ AlignmentMorph newColumn)).
	self addPageTwoControlsTo: col.
	self addToggleButtonsTo: col forPage: 2.

	book openToDragNDrop: false.
	book beThoroughlyRepelling.
	book goToPage: 1.
	^ book