resort: newMode
	"Re-sort the list of files."

	| name |
	listIndex > 0
		ifTrue: [name _ self fileNameFromFormattedItem: (list at: listIndex)].
	sortMode _ newMode.
	self pattern: pattern.
	name ifNotNil: [
		fileName _ name.
		listIndex _ list findFirst: [:item | (self fileNameFromFormattedItem: item) = name. ].
		self changed: #fileListIndex].
	listIndex = 0 ifTrue: [self changed: #contents].
	self updateButtonRow
