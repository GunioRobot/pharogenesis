mouseDown: evt
	| cp |
	TopWindow == self ifFalse: [self activate].
	(Sensor redButtonPressed "If mouse is really still down after activate"
			and: [self labelRect containsPoint: evt cursorPoint]) ifTrue:
		[^ self isSticky ifFalse:
			[self fastFramingOn 
				ifTrue: [self doFastFrameDrag]
				ifFalse: [evt hand grabMorph: self topRendererOrSelf]]].
	model windowActiveOnFirstClick ifTrue:
		["Normally window keeps control of first click.
		Need explicit transmission for first-click activity."
		cp _ evt cursorPoint.
		submorphs do: [:m | (m containsPoint: cp) ifTrue: [m mouseDown: evt]]]

