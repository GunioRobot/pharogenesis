beginAt: startCharIndex
	lastIndex _ startCharIndex.
	runStopIndex _ lastIndex + (text runLengthFor: lastIndex) - 1.
	self setFont