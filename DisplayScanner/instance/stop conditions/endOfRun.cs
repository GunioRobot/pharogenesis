endOfRun
	"The end of a run in the display case either means that there is actually 
	a change in the style (run code) to be associated with the string or the 
	end of this line has been reached."
	| runLength |
	self fillLeading.  "Fill any leading above or below the font"
	lastIndex = line last ifTrue: [^true].
	runX _ destX.
	runLength _ text runLengthFor: (lastIndex _ lastIndex + 1).
	runStopIndex _ lastIndex + (runLength - 1) min: line last.
	self setStopConditions.
	^ false