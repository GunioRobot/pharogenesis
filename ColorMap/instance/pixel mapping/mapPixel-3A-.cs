mapPixel: pixelValue
	"Perform a forward pixel mapping operation"
	| pv |
	(shifts == nil and:[masks == nil]) ifFalse:[
		pv _ (((pixelValue bitAnd: self redMask) bitShift: self redShift) bitOr:
			((pixelValue bitAnd: self greenMask) bitShift: self greenShift)) bitOr:
			(((pixelValue bitAnd: self blueMask) bitShift: self blueShift) bitOr:
			((pixelValue bitAnd: self alphaMask) bitShift: self alphaShift)).
	] ifTrue:[pv _ pixelValue].
	colors ifNotNil:[pv _ colors at: pv].
	"Need to check for translucency else Form>>paint goes gaga"
	pv = 0 ifTrue:[pixelValue = 0 ifFalse:[pv _ 1]].
	^pv