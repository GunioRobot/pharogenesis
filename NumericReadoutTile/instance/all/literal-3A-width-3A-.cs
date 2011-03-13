literal: anObject width: w
	literal _ anObject.
	self updateLiteralLabelClipped.
	submorphs last
		setWidth: w;
		informTarget.
	self updateLiteralLabelClipped.
	"self acceptNewLiteral."		"Show that we are out of date, install is needed"
	"self updateLiteralLabel"
