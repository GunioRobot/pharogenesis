primSubScalar: scalarValue

	<primitive: 'primitiveFloatArraySubScalar'>
	1 to: self size do:[:i| self at: i put: (self at: i) - scalarValue].