resonatorC: index put: aFloat
	self inline: true.
	self returnTypeC: 'void'.
	self var: 'aFloat' declareC: 'float aFloat'.
	resonators at: index*5-3 put: aFloat