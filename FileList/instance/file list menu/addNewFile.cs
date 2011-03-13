addNewFile
	"Add a new file and update the list"
	| newName index ending |
	self okToChange ifFalse: [^ self].
	newName _ (FillInTheBlank request: 'New File Name?'
 					initialAnswer: 'FileName') asFileName.
	Cursor wait showWhile: [
		(directory newFileNamed: newName) close].
	self updateFileList.
	index _ list indexOf: newName.
	index = 0 ifTrue: [ending _ ') ',newName.
		index _ list findFirst: [:line | line endsWith: ending]].
	self fileListIndex: index.
