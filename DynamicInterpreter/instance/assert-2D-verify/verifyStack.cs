verifyStack
	| t1 t2 t3 |
	checkAssertions ifFalse: [^nil ].
	(t1 _ activeCachedContext) = 0
		ifTrue: [self print: 'Warning: no active context in #verifyStack';
			 cr]
		ifFalse: 
			[t2 _ 0.
			[t2 = 0]
				whileTrue: 
					[self verifyCachedContext: t1.
					t1 = lowestCachedContext ifTrue: [t2 _ self cachedSenderAt: t1].
					t1 _ self cachedContextBefore: t1].
			t2 = nilObj ifTrue: [self assertIsCachedBaseContext: lowestCachedContext].
			[t2 = nilObj]
				whileFalse: 
					[self verifyStableContext: t2.
					t3 _ self fetchPointer: SenderIndex ofObject: t2.
					t3 = nilObj ifTrue: [self assertIsStableBaseContext: t2].
					t2 _ t3].
			nil]