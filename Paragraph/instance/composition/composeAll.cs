composeAll
	"Compose a collection of characters into a collection of lines."

	| startIndex stopIndex lineIndex maximumRightX compositionScanner |
	lines := Array new: 32.
	lastLine := 0.
	maximumRightX := 0.
	text size = 0
		ifTrue:
			[compositionRectangle := compositionRectangle withHeight: 0.
			^maximumRightX].
	startIndex := lineIndex := 1.
	stopIndex := text size.
	compositionScanner := MultiCompositionScanner new forParagraph: self.
	[startIndex > stopIndex] whileFalse: 
		[self lineAt: lineIndex 
				put: (compositionScanner composeLine: lineIndex 
										fromCharacterIndex: startIndex 
										inParagraph: self).
		 maximumRightX := compositionScanner rightX max: maximumRightX.
		 startIndex := (lines at: lineIndex) last + 1.
		 lineIndex := lineIndex + 1].
	self updateCompositionHeight.
	self trimLinesTo: lineIndex - 1.
	^ maximumRightX