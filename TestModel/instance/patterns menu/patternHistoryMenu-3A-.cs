patternHistoryMenu: aMenuMorph

	self patternHistory isEmpty
		ifFalse: [
			"aMenuMorph addTitle: 'Selection Patterns'."
			self patternHistory do: [:each |
				aMenuMorph add: each selector: #patternText: argument: each].
			aMenuMorph
				addLine;
				add: 'alphabetize list' selector: #alphabetizePatternHistory argument: nil;
				add: 'clean-up list' selector: #cleanUpPatternHistory argument: nil;
				add: 'empty list' selector: #emptyPatternHistory argument: nil;
				addLine].
	aMenuMorph add: 'accept pattern (s)' selector: #acceptNewPattern argument: nil.
	^aMenuMorph