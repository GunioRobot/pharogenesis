mouseUp: evt
	| cp |
	model windowActiveOnFirstClick ifTrue:
		["Normally window takes control on first click.
		Need explicit transmission for first-click activity."
		cp _ evt cursorPoint.
		submorphs do: [:m | (m containsPoint: cp) ifTrue: [m mouseUp: evt]]]