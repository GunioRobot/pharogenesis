getGlyphFlagsFrom: entry size: nPts
	"Read in the flags for this glyph.  The outer loop gathers the flags that
	are actually contained in the table.  If the repeat bit is set in a flag
	then the next byte is read from the table; this is the number of times
	to repeat the last flag.  The inner loop does this, incrementing the
	outer loops index each time."
	| flags index repCount flagBits |
	flags _ ByteArray new: nPts.
	index _ 1.
	[index <= nPts] whileTrue:[
		flagBits _ entry nextByte.
		flags at: index put: flagBits.
		(flagBits bitAnd: 8) = 8 ifTrue:[
			repCount _ entry nextByte.
			repCount timesRepeat:[
				index _ index + 1.
				flags at: index put: flagBits]].
		index _ index + 1].
	^flags