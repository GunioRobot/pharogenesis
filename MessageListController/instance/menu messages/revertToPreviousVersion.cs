revertToPreviousVersion
	"Revert to the previous version of the current method"

	| aClass aSelector  changeRecords codeController |
	self controlTerminate.
	aClass _ model selectedClassOrMetaClass.
	aClass ifNil: [^ view flash].
	aSelector _ model selectedMessageName.
	changeRecords _ aClass changeRecordsAt: aSelector.
	changeRecords size <= 1 ifTrue: [view flash.  ^ self beep].
	codeController _ (view superView subViews detect: [:v | v isKindOf: StringHolderView]) controller.
	model contents: (changeRecords at: 2) string notifying: codeController.
	codeController view updateDisplayContents.
	self controlInitialize