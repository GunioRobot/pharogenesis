renameClass: class as: newName 
	"Include indication that a class has been renamed."

	| recorder |
	isolationSet ifNotNil:
		["If there is an isolation layer above me, inform it as well."
		isolationSet renameClass: class as: newName].
	(recorder _ self changeRecorderFor: class)
		noteChangeType: #rename;
		noteNewName: newName asSymbol.
		
	"store under new name (metaclass too)"
	changeRecords at: newName put: recorder.
	changeRecords removeKey: class name.
	self noteClassStructure: class.

	recorder _ changeRecords at: class class name ifAbsent: [^ nil].
	changeRecords at: (newName, ' class') put: recorder.
	changeRecords removeKey: class class name.
	recorder noteNewName: newName , ' class'