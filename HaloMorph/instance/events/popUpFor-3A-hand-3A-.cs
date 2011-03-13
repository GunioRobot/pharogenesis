popUpFor: aMorph hand: aHand
	"Programatically pop up a halo for a given hand."
	self target: aMorph.
	aHand halo: self.
	aHand world addMorphFront: self.
	positionOffset _ aHand position - (aMorph point: aMorph position in: owner).
	self startStepping.