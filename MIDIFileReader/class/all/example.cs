example
	"MIDIFileReader example"

	((MIDIFileReader scoreFromFileNamed: 'HappyHackerV2.mid')
		playRate: 1.05)
			instrumentForTrack: 1 put: FMSound brass2;
			instrumentForTrack: 3 put: FMSound bass1.
