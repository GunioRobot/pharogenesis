text: t textStyle: s
	"Private -- for use only in morphic duplication"
	text _ t.
	textStyle _ s.
	paragraph ifNotNil: [paragraph textStyle: s]