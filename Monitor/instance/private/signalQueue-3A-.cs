signalQueue: anOrderedCollection
	queuesMutex critical: [
		anOrderedCollection isEmpty ifTrue: [^ self].
		anOrderedCollection removeFirst signal.
	].