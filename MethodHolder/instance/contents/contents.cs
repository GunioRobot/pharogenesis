contents
	"Answer the contents, with due respect for my contentsSymbol"

	contents _ methodClass sourceCodeAt: methodSelector ifAbsent: [''].
	currentCompiledMethod _ methodClass compiledMethodAt: methodSelector ifAbsent: [nil].

	self showingDecompile ifTrue:
			[^ self decompiledSourceIntoContentsWithTempNames: Sensor leftShiftDown not ].

	self showingDocumentation ifTrue:
		[^ self commentContents].

	^ contents _ self sourceStringPrettifiedAndDiffed asText makeSelectorBoldIn: methodClass