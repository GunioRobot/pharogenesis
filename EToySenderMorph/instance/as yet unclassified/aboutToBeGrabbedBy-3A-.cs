aboutToBeGrabbedBy: aHand

	| aFridge |
	super aboutToBeGrabbedBy: aHand.
	aFridge _ self ownerThatIsA: EToyFridgeMorph.
	aFridge ifNil: [^self].
	aFridge noteRemovalOf: self.