aboutToBeGrabbedBy: aHand

	| aFridge |
	super aboutToBeGrabbedBy: aHand.
	aFridge := self ownerThatIsA: EToyFridgeMorph.
	aFridge ifNil: [^self].
	aFridge noteRemovalOf: self.