wearCostume: aMorph
	"If the receiver and argument are both kinds of SketchMorph, make the receiver wear the costume of the argument. Otherwise, do nothing. This default implementation does nothing."

	| p |
	((aMorph isKindOf: SketchMorph) or:
	 [aMorph isKindOf: MovieMorph]) ifTrue: [
		self changed.
		p _ self referencePosition.
		originalForm _ aMorph form.
		rotationCenter _ aMorph rotationCenter.
		self referencePosition: p.
		self layoutChanged].
