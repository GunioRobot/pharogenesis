assertIsCachedBaseContext: t1 
	(self printCachedContext: t1)
		= '[] in BlockContext>>#newProcess' ifFalse: [self error: 'incorrect cached base context']