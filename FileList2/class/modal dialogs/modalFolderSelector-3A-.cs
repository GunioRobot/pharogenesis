modalFolderSelector: aDir

	| window fileModel |
	window _ self morphicViewFolderSelector: aDir.
	fileModel _ window model.
	window openInWorld: self currentWorld extent: 300@400.
	self modalLoopOn: window.
	^fileModel getSelectedDirectory withoutListWrapper