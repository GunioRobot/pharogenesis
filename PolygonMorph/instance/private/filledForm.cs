filledForm
	"Computation of the filled form is done only on demand"
	| bb origin |
	closed ifFalse: [^ filledForm _ nil].
	filledForm ifNotNil: [^ filledForm].
	filledForm _ ColorForm extent: bounds extent.
	bb _ (BitBlt toForm: filledForm) sourceForm: nil; fillColor: Color black;
			combinationRule: Form over; width: 1; height: 1.
	origin _ bounds topLeft.
	self lineSegmentsDo: [:p1 :p2 | bb drawFrom: p1 asIntegerPoint-origin
										to: p2 asIntegerPoint-origin].
	quickFill ifTrue: [filledForm convexShapeFill: Color black]
			ifFalse: ["Someday put a better fill algorithm here"].
	^ filledForm