updateLowestNote
	"find the actual lowest note in the score"

	| n |
	lowestNote _ 128 - (self innerBounds height // 3).
	score tracks do: [:track |
		1 to: track size do: [:i |
			n _ track at: i.
			(n isNoteEvent and: [n midiKey < lowestNote])
				ifTrue: [lowestNote _ n midiKey - 4]]].
