openAsIsIn: aWorld
	"This msg and its callees result in the window being activeOnlyOnTop"
	aWorld addMorph: self.
	self activate.
	aWorld startSteppingSubmorphsOf: self.
