modalFolderSelector: aDir

	| window fileModel |
	window _ self morphicViewFolderSelector: aDir.
	fileModel _ window model.
	window openInWorld: self currentWorld extent: 300@400.
	[window world notNil] whileTrue: [
		window outermostWorldMorph doOneCycle.
	].
	^fileModel getSelectedDirectory withoutListWrapper