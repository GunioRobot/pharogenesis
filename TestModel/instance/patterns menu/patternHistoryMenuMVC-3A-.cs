patternHistoryMenuMVC: aCustomMenu

	self patternHistory isEmpty
		ifFalse: [
			"aCustomMenu title: 'Selection Patterns'."
			self patternHistory do: [:each |
				aCustomMenu add: each action: each].
			aCustomMenu
				addLine;
				add: 'alphabetize list' action: #alphabetizePatternHistory;
				add: 'clean-up list' action: #cleanUpPatternHistory;
				add: 'empty list' action: #emptyPatternHistory;
				addLine].
	aCustomMenu add: 'accept pattern (s)' action: #acceptNewPattern.
	^aCustomMenu