selectedMessage
	"Answer the source method for the currently selected message."

	(categoryList notNil and: [(categoryListIndex isNil or: [categoryListIndex == 0])])
		ifTrue:
			[^ '---'].

	self setClassAndSelectorIn: [:class :selector | 
		class ifNil: [^ 'here would go the documentation for the protocol category, if any.'].

		self showingDecompile ifTrue:
			[^ self decompiledSourceIntoContentsWithTempNames: Sensor leftShiftDown not ].

		self showingDocumentation ifTrue:
			[^ self commentContents].

		currentCompiledMethod _ class compiledMethodAt: selector ifAbsent: [nil].
		^ self sourceStringPrettifiedAndDiffed asText makeSelectorBoldIn: class]