mouseDown: evt

	self setProperty: #clickPoint toValue: evt cursorPoint.
	TopWindow == self ifFalse:
		[evt hand releaseKeyboardFocus.
		self activate].
	model windowActiveOnFirstClick ifTrue:
		["Normally window keeps control of first click.
		Need explicit transmission for first-click activity."
		submorphs do: [:m | (m containsPoint: evt cursorPoint) ifTrue: [m mouseDown: evt]]]

