mouseDown: evt
	"Handle the transitions."
	
	self enabled ifFalse: [^self perform: #mouseDown: withArguments: {evt} inSuperclass: Morph].
	self isOn
		ifTrue: [self state: #repressed]
		ifFalse: [self state: #pressed].
	actWhen == #buttonDown
		ifTrue:
			[self doButtonAction].
	self mouseStillDown: evt.