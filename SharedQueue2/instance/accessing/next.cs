next
	^monitor critical: [
		monitor waitUntil: [ items isEmpty not ].
		items removeFirst ]
