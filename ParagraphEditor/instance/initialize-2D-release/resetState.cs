resetState 
	"Establish the initial conditions for editing the paragraph: place caret 
	before first character, set the emphasis to that of the first character,
	and save the paragraph for purposes of canceling."

	startBlock _ paragraph defaultCharacterBlock.
	stopBlock _ startBlock copy.
	beginTypeInBlock _ nil.
	UndoInterval _ otherInterval _ 1 to: 0.
	self setEmphasisHere.
	selectionShowing _ false.
	initialText _ paragraph text copy