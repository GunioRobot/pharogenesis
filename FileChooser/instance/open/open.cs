open
	| model |
	self postOpen. "Funny name in this context, should be renamed, but whatever..."
	self morphicView openInWorld.
	model := self morphicView model.
	FileChooser modalLoopOn: self morphicView.
	^ model getSelectedFile.
