assertIsCompiledMethodOrInteger: t1 
	self inline: false.
	self assertIsOop: t1.
	((self isIntegerObject: t1)
		or: [(self fetchClassOf: t1)
				== (self splObj: ClassCompiledMethod)])
		ifFalse: [self error: 'CompiledMethod expected']