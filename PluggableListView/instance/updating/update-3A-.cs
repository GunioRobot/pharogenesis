update: aSymbol 
	"Refer to the comment in View|update:."
	aSymbol == getListSelector ifTrue:
		[self list: self getList.
		self displayView.
		self displaySelectionBox.
		^self].
	aSymbol == getSelectionSelector ifTrue:
		[^ self moveSelectionBox: self getCurrentSelectionIndex].
	aSymbol == #closeScrollBar ifTrue:
		[^ controller controlTerminate].
