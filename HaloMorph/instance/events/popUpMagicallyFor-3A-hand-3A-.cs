popUpMagicallyFor: aMorph hand: aHand
	"Programatically pop up a halo for a given hand."
	Preferences magicHalos ifTrue:[
		self isMagicHalo: true.
		self magicAlpha: 0.2].
	self target: aMorph.
	aHand halo: self.
	aHand world addMorphFront: self.
	Preferences haloTransitions ifTrue:[
		self magicAlpha: 0.0.
		self startSteppingSelector: #fadeInInitially.
	].
	positionOffset _ aHand position - (aMorph point: aMorph position in: owner).
	self startStepping.