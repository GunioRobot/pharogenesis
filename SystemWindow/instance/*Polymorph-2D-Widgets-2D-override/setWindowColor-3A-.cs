setWindowColor: incomingColor
	"Removed existing color check - looked useless!"
	
	| aColor |
	incomingColor ifNil: [^ self].  "it happens"
	aColor := incomingColor.
	(aColor = ColorPickerMorph perniciousBorderColor 
		or: [aColor = Color black]) ifTrue: [^ self].
	self setProperty: #paneColor toValue: aColor.
	self setStripeColorsFrom: aColor.
	Preferences fadedBackgroundWindows ifFalse: [
		self adoptPaneColor: aColor]. "reverse optimisation"
	self changed.