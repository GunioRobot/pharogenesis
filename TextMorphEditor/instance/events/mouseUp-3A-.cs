mouseUp: evt
	"An attempt to break up the old processRedButton code into threee phases"
	oldInterval ifNil: [^ self].  "Patched during clickAt: repair"
	(startBlock = stopBlock 
		and: [oldInterval = (startBlock stringIndex to: startBlock stringIndex-1)])
		ifTrue: [self selectWord].
	self setEmphasisHere.
	(self isDisjointFrom: oldInterval) ifTrue:
		[otherInterval _ oldInterval].
	self storeSelectionInParagraph