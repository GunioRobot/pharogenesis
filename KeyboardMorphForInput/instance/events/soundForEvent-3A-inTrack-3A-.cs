soundForEvent: noteEvent inTrack: trackIndex

	| sound player |
	player _ pianoRoll scorePlayer.
	sound _ MixedSound new.
	sound add: ((player instrumentForTrack: trackIndex)
					soundForMidiKey: noteEvent midiKey
					dur: noteEvent duration / (pianoRoll scorePlayer ticksForMSecs: 1000)
					loudness: (noteEvent velocity asFloat / 127.0))
			pan: (player panForTrack: trackIndex)
			volume: player overallVolume *
						(player volumeForTrack: trackIndex).
	^ sound
