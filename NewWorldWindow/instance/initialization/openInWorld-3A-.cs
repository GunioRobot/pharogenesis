openInWorld: aWorld
	| xxx |
	"This msg and its callees result in the window being activeOnlyOnTop"

	xxx _ RealEstateAgent initialFrameFor: self world: aWorld.

	"Bob say: 'opening in ',xxx printString,' out of ',aWorld bounds printString.
	6 timesRepeat: [Display flash: xxx andWait: 300]."

	self bounds: xxx.
	^self openAsIsIn: aWorld.