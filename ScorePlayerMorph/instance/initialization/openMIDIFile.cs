openMIDIFile
	"Open a MIDI score and re-init controls..."
	| score fileName f player |
	fileName _ Utilities chooseFileWithSuffixFromList: #('.mid' '.midi')
					withCaption: 'Choose a MIDI file to open'.
	fileName ifNil: [^ self].
	f _ FileStream readOnlyFileNamed: fileName.
	score _ (MIDIFileReader new readMIDIFrom: f binary) asScore.
	f close.
	player _ ScorePlayer onScore: score.
	self onScorePlayer: player title: fileName