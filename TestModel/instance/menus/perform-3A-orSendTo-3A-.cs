perform: selector orSendTo: otherTarget

	(#(	#alphabetizePatternHistory
		#cleanUpPatternHistory
		#emptyPatternHistory
		#acceptNewPattern) includes: selector)
			ifTrue: [self perform: selector]
			ifFalse: [self patternText: selector].