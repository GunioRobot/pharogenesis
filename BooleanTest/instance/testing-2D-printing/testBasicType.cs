testBasicType
	self
		should: [true basicType = #Boolean].
	self
		should: [false basicType = #Boolean].