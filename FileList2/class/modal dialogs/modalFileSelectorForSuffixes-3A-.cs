modalFileSelectorForSuffixes: aList

	| window aFileList |

	window _ self morphicViewFileSelectorForSuffixes: aList.
	aFileList _ window valueOfProperty: #fileListModel.
	window openCenteredInWorld.
	[window world notNil] whileTrue: [
		window outermostWorldMorph doOneCycle.
	].
	^aFileList getSelectedFile