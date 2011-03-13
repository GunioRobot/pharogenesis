fail
	failBlock isNil ifFalse: [^failBlock value].
	self error: 'Reading a number failed'