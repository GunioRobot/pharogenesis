signalAllInQueue: anOrderedCollection
	queuesMutex critical: [
		anOrderedCollection do: [:lock | lock signal].
		anOrderedCollection removeAllSuchThat: [:each | true].
	].