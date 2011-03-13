resetState 
	"Establish the initial conditions for editing the paragraph: place caret 
	before first character, set the emphasis to that of the first character,
	and save the paragraph for purposes of canceling."

	stopBlock := paragraph defaultCharacterBlock.
	self pointBlock: stopBlock copy.
	beginTypeInBlock := nil.
	UndoInterval := otherInterval := 1 to: 0.
	self setEmphasisHere.
	selectionShowing := false.
	initialText := paragraph text copy