text: t textStyle: s wrap: wrap color: c
	predecessor: pred successor: succ
	"Private -- for use only in morphic duplication"
	text _ t.
	textStyle _ s.
	wrapFlag _ wrap.
	color _ c.
	paragraph _ editor _ container _ nil.
	self predecessor: pred successor: succ