playURLNamed: urlString
	"MIDIFileReader playURLNamed: 'http://www.midiworld.com/mid/c2/wtellovr.mid'"
	"MIDIFileReader playURLNamed: 'http://www.midiworld.com/mid/c2/barbero.mid'"
	| titleString |
	titleString _ urlString copyFrom: (urlString findLast: [:c | c=$/])+1
						to: urlString size.
	ScorePlayerMorph
		openOn: (self scoreFromURL: urlString)
		title: titleString.
