resort: newMode
	"Re-sort the list of files."

	| name |
	listIndex > 0
		ifTrue: [name _ self fileNameFromFormattedItem: (list at: listIndex)].
	sortMode _ newMode.
	self pattern: pattern.
	name ifNotNil:
		[listIndex _ list findFirst: [:item | (self fileNameFromFormattedItem: item) = name].
		self changed: #fileListIndex].
