pushFloat: f

	self var: #f declareC: 'double f'.
	self push: (self floatObjectOf: f).