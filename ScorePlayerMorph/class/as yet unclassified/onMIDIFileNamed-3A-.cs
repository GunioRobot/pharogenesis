onMIDIFileNamed: fileName
	"Return a ScorePlayerMorph on the score from the MIDI file of the given name."

	| score player |
	score _ MIDIFileReader scoreFromFileNamed: fileName	.
	player _ ScorePlayer onScore: score.
	^ self new onScorePlayer: player title: fileName
