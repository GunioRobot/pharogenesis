literal: anObject

	literal _ anObject.
	self updateLiteralLabel.
	self acceptNewLiteral.		"Show that we are out of date, install is needed"
