resonatorP1: index put: aFloat
	self inline: true.
	self returnTypeC: 'void'.
	self var: 'aFloat' declareC: 'float aFloat'.
	resonators at: index*5-2 put: aFloat