pitchTable
	"AbstractSound pitchTable"

	| out note i |
	out _ WriteStream on: (String new: 1000).
	i _ 12.
	0 to: 8 do: [:octave |
		#(c 'c#' d eb e f fs g 'g#' a bf b) do: [:noteName |
			note _ noteName, octave printString.
			out nextPutAll: note; tab.
			out nextPutAll: i printString; tab.
			out nextPutAll: (AbstractSound pitchForName: note) printString; cr.
			i _ i + 1]].
	^ out contents
