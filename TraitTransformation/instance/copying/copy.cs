copy
	self error: 'should not be called'.
	^super copy
		subject: self subject copy;
		yourself