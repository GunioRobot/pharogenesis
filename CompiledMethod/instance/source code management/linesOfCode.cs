linesOfCode
	"An approximate measure of lines of code.
	Includes comments, but excludes blank lines."
	| strm line lines |
	lines _ 0.
	strm _ ReadStream on: self getSource.
		[strm atEnd] whileFalse:
			[line _ strm upTo: Character cr.
			line isEmpty ifFalse: [lines _ lines+1]].
	^lines 