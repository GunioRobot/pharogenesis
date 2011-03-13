setLiteralTo: anObject width: w
	"like literal:width: but does not inform the target"
	literal _ anObject.
	self updateLiteralLabelClipped.
	submorphs last
		setWidth: w.
	self updateLiteralLabelClipped