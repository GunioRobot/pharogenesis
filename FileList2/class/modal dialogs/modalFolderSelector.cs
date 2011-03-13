modalFolderSelector

	| window fileModel |
	window _ self morphicViewFolderSelector.
	fileModel _ window model.
	window openInWorld: self currentWorld extent: 300@400.
	[window world notNil] whileTrue: [
		window outermostWorldMorph doOneCycleNow.
	].
	^fileModel getSelectedDirectory withoutListWrapper