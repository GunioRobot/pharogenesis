modalFolderSelectorForProject: aProject
"
FileList2 modalFolderSelectorForProject: Project current
"
	| window fileModel w |

	window _ FileList2 morphicViewProjectSaverFor: aProject.
	fileModel _ window valueOfProperty: #FileList.
	w _ self currentWorld.
	window position: w topLeft + (w extent - window extent // 2).
	window openInWorld: w.
	[window world notNil] whileTrue: [
		window outermostWorldMorph doOneCycleNow.
	].
	^fileModel getSelectedDirectory withoutListWrapper