selectedMessage
	"Answer a copy of the source code for the selected message."

	| class selector method |
	contents == nil ifFalse: [^ contents copy].

	self showingDecompile ifTrue:
		[^ self decompiledSourceIntoContentsWithTempNames: Sensor leftShiftDown not ].

	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	method _ class compiledMethodAt: selector ifAbsent: [^ ''].	"method deleted while in another project"
	currentCompiledMethod _ method.

	^ contents _ (self showingDocumentation
		ifFalse: [ self sourceStringPrettifiedAndDiffed ]
		ifTrue: [ self commentContents ])
			copy asText makeSelectorBoldIn: class