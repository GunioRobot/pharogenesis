renameFile
	"Rename the currently selected file"
	| newName index |
	listIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	newName _ (FillInTheBlank request: 'NewFileName?' 					initialAnswer: fileName) asFileName.
	newName = fileName ifTrue: [^ self].
	directory rename: fileName toBe: newName.
	self newList.
	index _ list indexOf: newName ifAbsent: [^0].
	self toggleFileListIndex: index