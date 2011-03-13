modalFileSelectorForSuffixes: aList directory: aDirectory

	| window aFileList |

	window _ self morphicViewFileSelectorForSuffixes: aList directory: aDirectory.
	aFileList _ window valueOfProperty: #fileListModel.
	window openCenteredInWorld.
	self modalLoopOn: window.
	^aFileList getSelectedFile