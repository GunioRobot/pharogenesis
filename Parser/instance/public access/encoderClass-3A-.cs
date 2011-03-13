encoderClass: anEncoderClass
	encoder notNil ifTrue:
		[self error: 'encoder already set'].
	encoder := anEncoderClass new