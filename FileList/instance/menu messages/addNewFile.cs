addNewFile
	"Add a new file and update the list"
	| newName index |
	self okToChange ifFalse: [^ self].
	newName _ (FillInTheBlank request: 'New File Name?' 					initialAnswer: 'FileName') asFileName.
	(directory newFileNamed: newName) close.
	self newList.
	index _ list indexOf: newName ifAbsent: [^0].
	self toggleFileListIndex: index