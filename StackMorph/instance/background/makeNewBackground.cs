makeNewBackground
	"Make a new background for the stack.  Obtain a name for it from the user.  It starts out life empty"

	| aName aColor newPage |
	aName _ FillInTheBlank request: 'What should we call this new background?' initialAnswer: 'alternateBackground'.
	aName isEmptyOrNil ifTrue: [^ self].
	aColor _ self color muchLighter.
	newPage _ PasteUpMorph newSticky extent: currentPage extent; color: aColor.
	newPage beAStackBackground.
	newPage borderWidth: currentPage borderWidth; borderColor: currentPage borderColor.
	newPage setNameTo: aName.
	newPage resizeToFit: false.
	pages isEmpty
		ifTrue: [pages add: newPage]
		ifFalse: [pages add: newPage after: currentPage].
	cards add: newPage currentDataInstance after: currentPage currentDataInstance.
	self nextPage.
