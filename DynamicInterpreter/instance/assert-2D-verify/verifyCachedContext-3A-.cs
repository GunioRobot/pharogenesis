verifyCachedContext: t1 
	| t2 t3 t4 t5 |
	self cachedMethodAt: t1.
	self cachedTranslatedMethodAt: t1.
	self cachedReceiverAt: t1.
	self cachedHomeAt: t1.
	t2 _ self cachedPseudoContextAt: t1.
	t2 == 0
		ifFalse: [(self pseudoCachedContextAt: t2)
				== t1 ifFalse: [self error: 'cached/pseudo context backpointers broken']].
	t3 _ self cachedFramePointerAt: t1.
	t4 _ self cachedStackPointerAt: t1.
	t5 _ t4 + 4 - t3 // 4.
	t5 < 0 ifTrue: [self error: 'cached stack underflow'].
	t5 > 32 ifTrue: [self error: 'cached stack overflow'].
	t3
		to: t4
		by: 4
		do: [:t6 | self okayFields: (self longAt: t6)]