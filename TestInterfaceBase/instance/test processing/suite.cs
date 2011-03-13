suite

	| suite |
	suite := TestSuite new.
	self matchingClasses do: [:class |
		| matchingSelectors |
		matchingSelectors := class selectors select: [:selector |
			self selectorPattern match: selector].
		matchingSelectors do: [:selector |
			suite addTest: (class selector: selector)]].
	^suite