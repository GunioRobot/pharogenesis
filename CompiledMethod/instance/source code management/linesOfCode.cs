linesOfCode
	"An approximate measure of lines of code.
	Includes comments, but excludes blank lines."
	| strm line lines |
	lines := 0.
	strm := self getSource readStream.
	[ strm atEnd ] whileFalse: 
		[ line := strm upTo: Character cr.
		line isEmpty ifFalse: [ lines := lines + 1 ] ].
	^ lines