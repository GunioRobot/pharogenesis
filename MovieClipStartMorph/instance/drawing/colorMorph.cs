colorMorph
	colorMorph ifNotNil: [^ colorMorph].

	"Make up a morph to highlight the span of this clip."
	ColorIndex _ (ColorIndex ifNil: [0]) + 2 \\ 8 + 1.
	^ colorMorph _ Morph newBounds: (0@0 extent: 9@9) color: ((Color wheel: 8) at: ColorIndex)
