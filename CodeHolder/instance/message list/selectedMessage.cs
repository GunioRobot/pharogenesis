selectedMessage
	"Answer a copy of the source code for the selected message.  This generic version is probably actually never reached, since every subclass probably reimplements and does not send to super.  In time, ideally, most, or all, reimplementors would vanish and all would defer instead to a universal version right here.  Everything in good time."

	| class selector method |
	contents ifNotNil: [^ contents copy].

	self showingDecompile ifTrue:
		[^ self decompiledSourceIntoContentsWithTempNames: Sensor leftShiftDown not ].

	class _ self selectedClassOrMetaClass.
	(class isNil or: [(selector _ self selectedMessageName) isNil]) ifTrue: [^ ''].
	method _ class compiledMethodAt: selector ifAbsent: [^ ''].	"method deleted while in another project"
	currentCompiledMethod _ method.

	^ contents _ (self showComment
		ifFalse: [self sourceStringPrettifiedAndDiffed]
		ifTrue:	[ self commentContents])
			copy asText makeSelectorBoldIn: class