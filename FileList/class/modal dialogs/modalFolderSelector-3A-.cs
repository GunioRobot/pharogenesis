modalFolderSelector: aDir

	| window fileModel |
	window := self morphicViewFolderSelector: aDir.
	fileModel := window model.
	window openInWorld: self currentWorld extent: 300@400.
	self modalLoopOn: window.
	^fileModel getSelectedDirectory withoutListWrapper