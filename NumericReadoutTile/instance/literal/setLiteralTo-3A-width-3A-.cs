setLiteralTo: anObject width: w
	"like literal:width: but does not inform the target"
	literal _ anObject.
	self updateLiteralLabel.
	submorphs last setWidth: w.
	self updateLiteralLabel