mouseDownPitch: midiKey event: event noteMorph: keyMorph

	| sel noteEvent |
	event hand hasSubmorphs ifTrue: [^ self  "no response if drag something over me"].
	keyMorph color: playingKeyColor.
	(sel _ pianoRoll selection) ifNil: [^ self].
	insertMode ifTrue:
		[sel _ pianoRoll selectionForInsertion.
		insertMode _ false].
	sel = prevSelection ifFalse:
		["This is a new selection -- need to determine start time"
		sel third = 0
			ifTrue: [startOfNextNote _ 0]
			ifFalse: [startOfNextNote _ ((pianoRoll score tracks at: sel first)
										at: sel third) endTime.
					startOfNextNote _ startOfNextNote + self fullDuration - 1
										truncateTo: self fullDuration]].
	noteEvent _ NoteEvent new time: startOfNextNote; duration: self noteDuration;
			key: midiKey + 23 velocity: self velocity channel: 1.
	pianoRoll appendEvent: noteEvent fullDuration: self fullDuration.
	soundPlaying ifNotNil: [soundPlaying stopGracefully].
	(soundPlaying _ self soundForEvent: noteEvent inTrack: sel first) play.
	prevSelection _ pianoRoll selection.
	startOfNextNote _ startOfNextNote + self fullDuration.