mouseUp: evt
	"Allow on:send:to: to set the response to events other than actWhen"
	
	self enabled ifFalse: [^self perform: #mouseUp: withArguments: {evt} inSuperclass: Morph].
	actWhen == #buttonUp
		ifFalse: [^self perform: #mouseUp: withArguments: {evt} inSuperclass: Morph].
	(self containsPoint: evt cursorPoint)
		ifTrue: [state == #repressed
					ifTrue: [self state: #off]
					ifFalse: [self state: #on].
				self doButtonAction: evt]
		ifFalse: [target ifNotNil: [target mouseUpBalk: evt]].
	^self perform: #mouseDown: withArguments: {evt} inSuperclass: Morph