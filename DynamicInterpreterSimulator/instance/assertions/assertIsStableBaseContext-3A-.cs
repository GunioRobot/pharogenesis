assertIsStableBaseContext: t1 
	self assertIsOop: t1.
	(self printStableContext: t1)
		= '[] in BlockContext>>#newProcess' ifFalse: [self error: 'incorrect stable base context']