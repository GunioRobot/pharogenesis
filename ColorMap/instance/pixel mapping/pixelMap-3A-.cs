pixelMap: pixelValue
	"Perform a reverse pixel mapping operation"
	| pv |
	colors == nil
		ifTrue:[pv _ pixelValue]
		ifFalse:[pv _ colors at: pixelValue].
	(shifts == nil and:[masks == nil]) 
		ifTrue:[^pv]
		ifFalse:[^(((pv bitAnd: self redMask) bitShift: self redShift) bitOr: 
				((pv bitAnd: self greenMask) bitShift: self greenShift)) bitOr:
					(((pv bitAnd: self blueMask) bitShift: self blueShift) bitOr: 
						((pv bitAnd: self alphaMask) bitShift: self alphaShift))]