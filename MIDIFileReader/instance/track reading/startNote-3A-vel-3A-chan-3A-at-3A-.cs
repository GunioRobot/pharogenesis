startNote: midiKey vel: vel chan: chan at: startTicks
	"Record the beginning of a note."
	"Details: Some MIDI scores have missing note-off events, causing a note-on to be received for a (key, channel) that is already sounding. If the previous note is suspiciously long, truncate it."

	| newActiveEvents dur noteOnEvent |
	newActiveEvents := nil.
	activeEvents do: [:e |
		((e midiKey = midiKey) and: [e channel = chan]) ifTrue: [
			"turn off key already sounding"
			dur := startTicks - e time.
			dur > maxNoteTicks ifTrue: [dur := ticksPerQuarter].  "truncate"
			e duration: dur.
			newActiveEvents ifNil: [newActiveEvents := activeEvents copy].
			newActiveEvents remove: e ifAbsent: []]].
	newActiveEvents ifNotNil: [activeEvents := newActiveEvents].

	noteOnEvent := NoteEvent new key: midiKey velocity: vel channel: chan.
	noteOnEvent time: startTicks.
	track add: noteOnEvent.
	activeEvents add: noteOnEvent.
