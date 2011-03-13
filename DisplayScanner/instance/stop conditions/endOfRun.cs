endOfRun
	"The end of a run in the display case either means that there is actually 
	a change in the style (run code) to be associated with the string or the 
	end of this line has been reached. A check for any emphasis 
	(underlining, for example) that may run the length of the run is done 
	here before returning to displayLines: to do the next line."

	| runLength |
	self checkEmphasis.
	lastIndex = line last ifTrue: [^true].
	runX _ destX.
	runLength _ text runLengthFor: (lastIndex _ lastIndex + 1).
	(runStopIndex _ lastIndex + (runLength - 1)) > line last 
		ifTrue: [runStopIndex _ line last].
	self setStopConditions.
	destY _ lineY + textStyle baseline - font ascent.
	"ascent delta"
	^false