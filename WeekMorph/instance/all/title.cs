title
	"Answer a title with the names of the days."
	| title extent days |
	title _ AlignmentMorph new
		layoutInset: 0;
		color: Color red;
		listDirection: #leftToRight;
		vResizing: #shrinkWarp;
		height: tileRect height.
		extent _ self tile extent.
		
	days _ (Week startDay = #Monday)
		ifTrue: [ #(2 3 4 5 6 7 1) ]
		ifFalse: [ 1 to: 7 ].
		
	(days reverse collect: [:each | Date nameOfDay: each]) do:
		[:each |
		title addMorph:
			((self tileLabeled: (each copyFrom: 1 to: 2))
				extent: extent)].
	^ title
	