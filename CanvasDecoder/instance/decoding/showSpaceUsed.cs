showSpaceUsed

	| total |
	CachedForms ifNil: [^self].
	total _ 0.
	CachedForms do: [ :each |
		each ifNotNil: [
			total _ total + (each depth * each width * each height // 8).
		].
	].
	(total // 1024) printString,'     ',
	(Smalltalk garbageCollectMost // 1024) printString,'     ' displayAt: 0@0