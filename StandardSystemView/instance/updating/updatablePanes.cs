updatablePanes
	"Answer the list of panes, in order, which might be sent the #verifyContents message upon window activation or expansion."
	^ updatablePanes ifNil: [updatablePanes _ #()]