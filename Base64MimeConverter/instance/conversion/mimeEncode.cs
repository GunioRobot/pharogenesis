mimeEncode
	"Convert from data to 6 bit characters."

	| phase1 phase2 raw nib |
	phase1 _ phase2 _ false.
	[dataStream atEnd] whileFalse: [
		data _ raw _ dataStream next asInteger.
		nib _ (data bitAnd: 16rFC) bitShift: -2.
		mimeStream nextPut: (ToCharTable at: nib+1).
		(raw _ dataStream next) ifNil: [raw _ 0. phase1 _ true].
		data _ ((data bitAnd: 3) bitShift: 8) + raw asInteger.
		nib _ (data bitAnd: 16r3F0) bitShift: -4.
		mimeStream nextPut: (ToCharTable at: nib+1).
		(raw _ dataStream next) ifNil: [raw _ 0. phase2 _ true].
		data _ ((data bitAnd: 16rF) bitShift: 8) + (raw asInteger).
		nib _ (data bitAnd: 16rFC0) bitShift: -6.
		mimeStream nextPut: (ToCharTable at: nib+1).
		nib _ (data bitAnd: 16r3F).
		mimeStream nextPut: (ToCharTable at: nib+1)].
	phase1 ifTrue: [mimeStream skip: -2; nextPut: $=; nextPut: $=.
			^ mimeStream].
	phase2 ifTrue: [mimeStream skip: -1; nextPut: $=.
			^ mimeStream].

