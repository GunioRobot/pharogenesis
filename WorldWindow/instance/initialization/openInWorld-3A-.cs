openInWorld: aWorld
	"This msg and its callees result in the window being activeOnlyOnTop"
	self bounds: (RealEstateAgent initialFrameFor: self world: aWorld).
	self firstSubmorph position: (self left + 1) @ (self top + self labelHeight).
	^self openAsIsIn: aWorld