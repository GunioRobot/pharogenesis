modalFileSelectorForSuffixes: aList directory: aDirectory

	| window aFileList |

	window := self morphicViewFileSelectorForSuffixes: aList directory: aDirectory.
	aFileList := window valueOfProperty: #fileListModel.
	window openCenteredInWorld.
	self modalLoopOn: window.
	^aFileList getSelectedFile