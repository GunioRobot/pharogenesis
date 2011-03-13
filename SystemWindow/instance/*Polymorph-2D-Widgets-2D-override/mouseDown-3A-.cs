mouseDown: evt
	"Changed to properly process the mouse down event if passing to
	submorphs."
	
	(self valueOfProperty: #processingMouseDown) == true
		ifTrue: [^self]. "recursive handling"
	evt hand waitForClicksOrDrag: self event: evt. "allow double-click response"
	self setProperty: #clickPoint toValue: evt cursorPoint.
	TopWindow == self
		ifTrue: [self comeToFront] "rise above non-window morphs"
		ifFalse:[
			TopWindow ifNotNilDo: [:w |
			w rememberKeyboardFocus: evt hand keyboardFocus].
		evt hand releaseKeyboardFocus.
		self activate].
	model windowActiveOnFirstClick ifTrue:
		["Normally window keeps control of first click.
		Need explicit transmission for first-click activity."
		self setProperty: #processingMouseDown toValue: true.
		[evt wasHandled: false.
		self processEvent: evt]
			ensure: [self setProperty: #processingMouseDown toValue: false]]