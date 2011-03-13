modalFileSelectorForSuffixes: aList

	| window aFileList |

	window _ self morphicViewFileSelectorForSuffixes: aList.
	aFileList _ window valueOfProperty: #fileListModel.
	window openCenteredInWorld.
	self modalLoopOn: window.
	^aFileList getSelectedFile