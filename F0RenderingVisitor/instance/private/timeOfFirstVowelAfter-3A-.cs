timeOfFirstVowelAfter: time
	| currentTime |
	currentTime _ 0.
	clause events do: [ :each |
		(currentTime >= time and: [each phoneme isSyllabic]) ifTrue: [^ currentTime].
		currentTime _ currentTime + each duration].
	^ time "if not found, answer the time itself"