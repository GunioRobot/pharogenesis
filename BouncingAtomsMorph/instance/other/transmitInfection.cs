transmitInfection

	| infected count |
	self collisionPairs do: [:pair |
		infected _ false.
		pair do: [:atom | atom infected ifTrue: [infected _ true]].
		infected
			ifTrue: [pair do: [:atom | atom infected: true]]].

	count _ 0.
	self submorphsDo: [:m | m infected ifTrue: [count _ count + 1]].
	infectionHistory addLast: count.
	count = submorphs size ifTrue: [
		transmitInfection _ false.
		self stopStepping].
