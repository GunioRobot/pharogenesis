pushFloat: f
	self var: #f declareC: 'double f'.
	f class == Float ifFalse:[^self error:'Not a Float'].
	self push: f.