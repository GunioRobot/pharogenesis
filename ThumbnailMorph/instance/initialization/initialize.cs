initialize
	"Initialize the receiver, obeying a #nominalExtent property if I  
	have one"
	| anExtent |
	super initialize.
	""
	anExtent _ self
				valueOfProperty: #nominalExtent
				ifAbsent: [25 @ 25].
	self
		extent: (anExtent
				)