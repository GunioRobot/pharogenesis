startNote: midiKey vel: vel chan: chan at: startTicks
	"Record the beginning of a note."
	"Details: Some MIDI scores have missing note-off events, causing a note-on to be received for a (key, channel) that is already sounding. If the previous note is suspiciously long, truncate it."

	| newActiveEvents dur noteOnEvent |
	newActiveEvents _ nil.
	activeEvents do: [:e |
		((e midiKey = midiKey) and: [e channel = chan]) ifTrue: [
			"turn off key already sounding"
			dur _ startTicks - e time.
			dur > maxNoteTicks ifTrue: [dur _ ticksPerQuarter].  "truncate"
			e duration: dur.
			newActiveEvents ifNil: [newActiveEvents _ activeEvents copy].
			newActiveEvents remove: e ifAbsent: []]].
	newActiveEvents ifNotNil: [activeEvents _ newActiveEvents].

	noteOnEvent _ NoteEvent new key: midiKey velocity: vel channel: chan.
	noteOnEvent time: startTicks.
	track add: noteOnEvent.
	activeEvents add: noteOnEvent.
