actWhen: condition

	(#(buttonDown mouseDown) includes: condition) ifTrue: [ actWhen _ #mouseDown ].
	(#(buttonUp mouseUp) includes: condition) ifTrue: [ actWhen _ #mouseUp ].
	(#(whilePressed mouseStillDown) includes: condition) ifTrue: [ actWhen _ #mouseStillDown ].
	self setEventHandlers: true.