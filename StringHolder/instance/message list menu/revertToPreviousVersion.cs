revertToPreviousVersion
	"Revert to the previous version of the current method"
	| aClass aSelector  changeRecords |
	self okToChange ifFalse: [^ self].
	aClass _ self selectedClassOrMetaClass.
	aClass ifNil: [^ self changed: #flash].
	aSelector _ self selectedMessageName.
	changeRecords _ aClass changeRecordsAt: aSelector.
	(changeRecords == nil or: [changeRecords size <= 1]) ifTrue: [self changed: #flash.  ^ self beep].
	changeRecords second fileIn.
	self contentsChanged
