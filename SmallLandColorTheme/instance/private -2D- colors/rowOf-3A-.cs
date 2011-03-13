rowOf: colors 
	| row |
	row := AlignmentMorph newRow.
	row cellInset: 5.
	row color: Color white.
	""
	colors
		do: [:each | 
			| box label | 
			box := RectangleMorph new.
			box extent: 100 @ 60.
			box color: each.
			box borderWidth: 2.
			box borderColor: box color muchDarker.
			""
			label := StringMorph
						contents: (self labelForColor: each).
			label color: each negated.
			box addMorphCentered: label.
			""
			row addMorphBack: box].
	""
	^ row 