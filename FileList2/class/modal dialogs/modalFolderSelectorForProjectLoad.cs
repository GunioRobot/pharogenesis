modalFolderSelectorForProjectLoad

	| window fileModel w |

	window _ self morphicViewProjectLoader2InWorld: self currentWorld reallyLoad: false.
	fileModel _ window valueOfProperty: #FileList.
	w _ self currentWorld.
	window position: w topLeft + (w extent - window extent // 2).
	window openInWorld: w.
	[window world notNil] whileTrue: [
		window outermostWorldMorph doOneCycle.
	].
	^fileModel getSelectedDirectory withoutListWrapper