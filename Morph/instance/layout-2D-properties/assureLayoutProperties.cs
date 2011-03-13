assureLayoutProperties
	| props |
	props _ self layoutProperties.
	props == self ifTrue:[props _ nil].
	props ifNil:[
		props _ LayoutProperties new initializeFrom: self.
		self layoutProperties: props].
	^props