title
	"Answer a title with the names of the days."
	| title extent days |
	title _ AlignmentMorph new
		inset: 0;
		color: Color red;
		orientation: #horizontal;
		vResizing: #shrinkWarp;
		height: 19.
		extent _ self tile extent.
	days _ Week startMonday
		ifTrue: [7 to: 1 by: -1]       "Original code, Mon-Sun."
		ifFalse: [#(6 5 4 3 2 1 7)].   "Sun-Sat."
	(days collect: [:each | Date nameOfDay: each]) do:
		[:each |
		title addMorph:
			((self tileLabeled: (each copyFrom: 1 to: 2))
				extent: extent;
				setBalloonText: each printString)].
	^ title
	