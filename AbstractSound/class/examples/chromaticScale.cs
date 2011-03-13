chromaticScale
	"PluckedSound chromaticScale play"

	^ self namedNoteSequenceFrom: #(
		(c4 0.5 400)
		(cs4 0.5 400)		"s means sharp"
		(d4 0.5 400)
		(eb4 0.5 400)	"b means flat (it looks like a flat sign in music notation)"
		(e4 0.5 400)
		(f4 0.5 400)
		('f#4' 0.5 400)	"# also means sharp, but it must be quoted within an array literal"
		(g4 0.5 400)
		(af4 0.5 400)		"f also means flat"
		(a4 0.5 400)
		(bb4 0.5 400)
		(b4 0.5 400)
		(c5 2.0 400))