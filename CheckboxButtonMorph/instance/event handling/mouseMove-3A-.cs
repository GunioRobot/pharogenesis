mouseMove: evt
	"Check for straying."
	
	self enabled ifFalse: [^self perform: #mouseMove: withArguments: {evt} inSuperclass: Morph].
	(self containsPoint: evt cursorPoint)
		ifTrue: [state == #on
					ifTrue: [self state: #repressed].
				state == #off
					ifTrue: [self state: #pressed].
				self perform: #mouseMove: withArguments: {evt} inSuperclass: Morph]
				"Allow on:send:to: to set the response to events other than actWhen"
		ifFalse: [state == #repressed
					ifTrue: [self state: #on].
				state == #pressed
					ifTrue: [self state: #off]].
