startNote: midiKey vel: vel chan: chan at: startTicks

	| noteOnEvent |
	noteOnEvent _ NoteEvent new key: midiKey velocity: vel channel: chan.
	noteOnEvent time: startTicks.
	track add: noteOnEvent.
	activeEvents add: noteOnEvent.
