transmitInfection

	| infected count graph |
	self collisionPairs do: [:pair |
		infected _ false.
		pair do: [:atom | atom infected ifTrue: [infected _ true]].
		infected
			ifTrue: [pair do: [:atom | atom infected: true]]].

	count _ 0.
	self submorphsDo: [:m | m infected ifTrue: [count _ count + 1]].
	infectionHistory addLast: count.
	count = submorphs size ifTrue: [
		"done! place a graph of the infection history in the world"
		graph _ GraphMorph new data: infectionHistory.
		graph position: bounds topRight + (10@0).
		graph extent: (((infectionHistory size * 3) + (2 * graph borderWidth))@count).
		self world addMorph: graph.
		graph changed.
		transmitInfection _ false.
		self stopStepping].
