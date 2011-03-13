revertToPreviousVersion
	"Revert to the previous version of the current method"

	| aClass aSelector  changeRecords codeController |
	aClass _ self selectedClassOrMetaClass.
	aClass ifNil: [^ self changed: #flash].
	aSelector _ self selectedMessageName.
	changeRecords _ aClass changeRecordsAt: aSelector.
	changeRecords size <= 1 ifTrue: [self changed: #flash.  ^ self beep].
	codeController _ (self dependents detect: [:v | v isKindOf: PluggableTextView]) controller.
		"later find a better way to do this!"
	self contents: (changeRecords at: 2) string notifying: codeController.
	self changed: #contents