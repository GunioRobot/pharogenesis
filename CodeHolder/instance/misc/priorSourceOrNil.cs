priorSourceOrNil
	"If the currently-selected method has a previous version, return its source, else return nil"
	| aClass aSelector  changeRecords |
	(aClass _ self selectedClassOrMetaClass) ifNil: [^ nil].
	(aSelector _ self selectedMessageName) ifNil: [^ nil].
	changeRecords _ aClass changeRecordsAt: aSelector.
	(changeRecords == nil or: [changeRecords size <= 1]) ifTrue: [^ nil].
	^ (changeRecords at: 2) string 
