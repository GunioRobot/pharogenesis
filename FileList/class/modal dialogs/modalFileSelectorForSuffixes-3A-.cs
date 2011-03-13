modalFileSelectorForSuffixes: aList

	| window aFileList |

	window := self morphicViewFileSelectorForSuffixes: aList.
	aFileList := window valueOfProperty: #fileListModel.
	window openCenteredInWorld.
	self modalLoopOn: window.
	^aFileList getSelectedFile