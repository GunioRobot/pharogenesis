assureTableProperties
	| props |
	props _ self layoutProperties.
	props == self ifTrue:[props _ nil].
	props ifNil:[
		props _ TableLayoutProperties new initializeFrom: self.
		self layoutProperties: props].
	props includesTableProperties 
		ifFalse:[self layoutProperties: (props _ props asTableLayoutProperties)].
	^props