endNote: midiKey chan: channel at: endTicks

	| evt |
	evt _ activeEvents
		detect: [:e | (e midiKey = midiKey) and: [e channel = channel]]
		ifNone: [^ self].
	evt duration: (endTicks - evt time).
	activeEvents remove: evt ifAbsent: [].
