renameFile
	"Rename the currently selected file"
	| newName response |
	listIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	(response _ FillInTheBlank request: 'NewFileName?' translated
 					initialAnswer: fileName)
		isEmpty ifTrue: [^ self].
	newName _ response asFileName.
	newName = fileName ifTrue: [^ self].
	directory rename: fileName toBe: newName.
	self updateFileList.
	listIndex _ list findFirst: [:item | (self fileNameFromFormattedItem: item) = newName].
	listIndex > 0 ifTrue: [fileName _ newName].
	self changed: #fileListIndex.
