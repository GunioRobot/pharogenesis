priorSourceOrNil
	"If the currently-selected method has a previous version, return its source, else return nil"
	| aClass aSelector  changeRecords |
	(aClass _ self selectedClass) ifNil: [^ nil].
	(aSelector _ self selectedMessageName) ifNil: [^ nil].
	changeRecords _  self class commentRecordsOf: self selectedClass.
	(changeRecords == nil or: [changeRecords size <= 1]) ifTrue: [^ nil].
	^ (changeRecords at: 2) string 
