renameFile
	"Rename the currently selected file"
	| newName |
	listIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	newName _ (FillInTheBlank request: 'NewFileName?'
 					initialAnswer: fileName) asFileName.
	newName = fileName ifTrue: [^ self].
	directory rename: fileName toBe: newName.
	self updateFileList.
	listIndex _ list findFirst: [:item | (self fileNameFromFormattedItem: item) = newName].
	listIndex > 0 ifTrue: [fileName _ newName].
	self changed: #fileListIndex.
