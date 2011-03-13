makeStatusLight
	"Create a status light to show when the recognizer is running."

	| s |
	statusLight := RectangleMorph new extent: 24@19.
	statusLight color: Color gray.
	s := StringMorph contents: 'On'.
	s position: statusLight center - (s extent // 2).
	statusLight addMorph: s.
	^ statusLight
