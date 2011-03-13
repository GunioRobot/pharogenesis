popUpFor: aMorph event: evt
	"This message is sent by morphs that explicitly request the halo on a button click. Note: anEvent is in aMorphs coordinate frame."
	| hand anEvent |
	self flag: #workAround. "We should really have some event/hand here..."
	evt isNil
		ifTrue:[	hand _ aMorph world activeHand.
				hand ifNil:[hand _ aMorph world primaryHand].
				anEvent _ hand lastEvent transformedBy: (aMorph transformedFrom: nil)]
		 ifFalse:[hand _ evt hand.
				anEvent _ evt].
	self target: aMorph.
	hand halo: self.
	hand world addMorphFront: self.
	positionOffset _ anEvent position - (aMorph point: aMorph position in: owner).
	self startStepping.