eudoraSeparator
	"Return a Eudora-style message separator string."

	| s today dateString |
	s _ WriteStream on: (String new: 50).
	today _ Date today.
	dateString _ today printFormat: #(2 1 3 32 2 1).
	dateString _ dateString copyFrom: 1 to: dateString size - 4.
	s nextPutAll: 'From ???@??? '.
	s nextPutAll: (today weekday copyFrom: 1 to: 3); space.
	s nextPutAll: dateString.
	Time now print24: true on: s.
	s space.
	s print: today year; cr.
	^s contents
