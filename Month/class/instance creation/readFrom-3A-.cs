readFrom: aStream
	| m y c |
	m _ (ReadWriteStream with: '') reset.
	[(c _ aStream next) isSeparator] whileFalse: [m nextPut: c].
	[(c _ aStream next) isSeparator] whileTrue.
	y _ (ReadWriteStream with: '') reset.
		y nextPut: c.
	[aStream atEnd] whileFalse: [y nextPut: aStream next].
	^ self fromDate: (Date newDay: 1 month: m contents asSymbol year: y contents asNumber)

	"
	Month readFrom: (ReadWriteStream with: 'July 1998') reset
	"