openAsIsIn: aWorld
	"This msg and its callees result in the window being activeOnlyOnTop.
	Play the open sound if the preference is enabled."
	
	self playOpenSound.
	aWorld addMorph: self.
	self activate.
	aWorld startSteppingSubmorphsOf: self.
