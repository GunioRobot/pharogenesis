update: aSymbol 
	"Refer to the comment in View|update:."

	| oldIndex newIndex |
	aSymbol == getListSelector ifTrue: [
		oldIndex _ self getCurrentSelectionIndex.
		self list: self getList.
		newIndex _ self getCurrentSelectionIndex.
		(oldIndex > 0 and: [newIndex = 0]) ifTrue: [
			"new list did not include the old selection; deselecting"
			self changeModelSelection: newIndex].
		self displayView.
		self displaySelectionBox.
		^self].
	aSymbol == getSelectionSelector ifTrue: [
		self moveSelectionBox: self getCurrentSelectionIndex.
		^self].
