step
	| newString enablement |
	super step.
	wordingProvider ifNotNil:
		[newString _ wordingProvider perform: wordingSelector.
		newString = contents ifFalse: [self contents: newString].
		enablementSelector ifNotNil:
			[enablement _ wordingProvider perform: enablementSelector.
			enablement == isEnabled ifFalse:
				[self isEnabled: enablement]]]