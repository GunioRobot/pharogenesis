/ aFactor
	"Answer this color with its RGB divided by aFactor or a vector of factors.  Try:
	((Color white) / 3) display		 a darkish gray.  
	((Color white) / #(1 1 2)) display	slightly less than blue.  6/18/96 tk"

(aFactor isKindOf: Number) ifTrue: [
	^ Color
		red: ((self red / aFactor) min: 1.0 max: 0.0)
		green: ((self green / aFactor) min: 1.0 max: 0.0)
		blue: ((self blue / aFactor) min: 1.0 max: 0.0)].

"(aFactor isKindOf: ArrayedCollection) ifTrue: ["
	^ Color
		red: ((self red / (aFactor at: 1)) min: 1.0 max: 0.0)
		green: ((self green / (aFactor at: 2)) min: 1.0 max: 0.0)
		blue: ((self blue / (aFactor at: 3)) min: 1.0 max: 0.0).
