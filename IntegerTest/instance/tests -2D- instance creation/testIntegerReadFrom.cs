testIntegerReadFrom
	self assert: (Integer readFrom: '123' readStream base: 10) = 123.
	self assert: (Integer readFrom: '-123' readStream base: 10) = -123.
	self assert: (Integer readFrom: 'abc' readStream base: 10) = 0.
	self assert: (Integer readFrom: 'D12' readStream base: 10) = 0.
	self assert: (Integer readFrom: '1two3' readStream base: 10) = 1.
