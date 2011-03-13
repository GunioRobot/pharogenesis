playURLNamed: urlString
	"MIDIFileReader playURLNamed: 'http://midiworld.com/mid/mjs/recson1.mid'"

	| titleString |
	titleString _ urlString copyFrom: (urlString findLast: [:c | c=$/])+1
						to: urlString size.
	ScorePlayerMorph
		openOn: (self scoreFromURL: urlString)
		title: titleString.
