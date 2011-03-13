literal: anObject width: w
	literal _ anObject.

	self updateLiteralLabelClipped.
	submorphs last
		setWidth: w;
		informTarget.
	self updateLiteralLabelClipped