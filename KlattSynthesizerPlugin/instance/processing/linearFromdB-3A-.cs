linearFromdB: aNumber
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'aNumber' declareC: 'double aNumber'.
	^ (2.0 raisedTo: (aNumber-87.0/6.0)) * 32.767