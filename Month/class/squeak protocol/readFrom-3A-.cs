readFrom: aStream

	| m y c |
	m := (ReadWriteStream with: '') reset.
	[(c := aStream next) isSeparator] whileFalse: [m nextPut: c].
	[(c := aStream next) isSeparator] whileTrue.
	y := (ReadWriteStream with: '') reset.
	y nextPut: c.
	[aStream atEnd] whileFalse: [y nextPut: aStream next].

	^ self 
		month: m contents
		year: y contents

"Month readFrom: 'July 1998' readStream"
