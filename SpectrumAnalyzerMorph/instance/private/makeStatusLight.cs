makeStatusLight

	| s |
	statusLight _ RectangleMorph new extent: 24@19.
	statusLight color: Color gray.
	s _ StringMorph contents: 'On'.
	s position: statusLight center - (s extent // 2).
	statusLight addMorph: s.
	^ statusLight
