selectedMessage
	"Answer the source method for the currently selected message."

	| source |
	self setClassAndSelectorIn: [:class :selector | 
		class ifNil: [^ 'Class vanished'].
		selector first isUppercase ifTrue:
			[selector == #Comment ifTrue:
				[currentCompiledMethod _ class organization commentRemoteStr.
				^ class comment].
			selector == #Definition ifTrue:
				[^ class definitionST80: Preferences printAlternateSyntax not].
			selector == #Hierarchy ifTrue: [^ class printHierarchy]].
		source _ class sourceMethodAt: selector ifAbsent:
			[currentCompiledMethod _ nil.
			^ 'Missing'].

		self showingDecompile ifTrue:
			[^ self decompiledSourceIntoContentsWithTempNames: Sensor leftShiftDown not ].

		currentCompiledMethod _ class compiledMethodAt: selector ifAbsent: [nil].
		self showingDocumentation ifTrue:
			[^ self commentContents].

	source _ self sourceStringPrettifiedAndDiffed.
	^ source asText makeSelectorBoldIn: class]