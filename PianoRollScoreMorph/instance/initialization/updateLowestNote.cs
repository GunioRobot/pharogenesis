updateLowestNote
	"find the actual lowest note in the score"

	| n |
	lowestNote := 128 - (self innerBounds height // 3).
	score tracks do: [:track |
		1 to: track size do: [:i |
			n := track at: i.
			(n isNoteEvent and: [n midiKey < lowestNote])
				ifTrue: [lowestNote := n midiKey - 4]]].
