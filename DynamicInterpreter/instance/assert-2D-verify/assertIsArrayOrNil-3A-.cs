assertIsArrayOrNil: t1 
	self inline: false.
	self assertIsOop: t1.
	(t1 = nilObj or: [(self fetchClassOf: t1) = (self splObj: ClassArray)])
		ifFalse: [self error: 'Array or nil expected']