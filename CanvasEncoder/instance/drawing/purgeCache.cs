purgeCache

	| spaceUsed spaceBefore s | 
	spaceBefore _ spaceUsed _ self purgeCacheInner.
	spaceBefore > 8000000 ifTrue: [
		Smalltalk garbageCollect.
		spaceUsed _ self purgeCacheInner.
	].
	false ifTrue: [
		s _ (spaceBefore // 1024) printString,'  ',(spaceUsed // 1024) printString,'  ',
			Time now printString,'     '.
		WorldState addDeferredUIMessage: [s displayAt: 0@0.] fixTemps.
	].
	^spaceUsed
