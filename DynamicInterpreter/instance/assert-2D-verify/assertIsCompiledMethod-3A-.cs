assertIsCompiledMethod: t1 
	self inline: false.
	self assertIsOop: t1.
	(self fetchClassOf: t1)
		== (self splObj: ClassCompiledMethod) ifFalse: [self error: 'CompiledMethod expected']