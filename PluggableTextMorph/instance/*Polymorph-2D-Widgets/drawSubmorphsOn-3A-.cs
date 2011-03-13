drawSubmorphsOn: aCanvas 
	"Display submorphs back to front.
	Draw the focus here since the drawOn: method is so horrible."

	super drawSubmorphsOn: aCanvas.
	Preferences externalFocusForPluggableText ifTrue: [
		self hasKeyboardFocus ifTrue: [self drawKeyboardFocusOn: aCanvas]]