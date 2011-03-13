literal: anObject
	literal _ anObject.
	self updateLiteralLabel.
	submorphs last informTarget.
	"self acceptNewLiteral."		"Show that we are out of date, install is needed"
	"self updateLiteralLabel"
