meanSquareError: otherData
	"Return the mean-square error between the current sample array and
	some other data, presumably to evaluate a compression scheme."
	| topSum bottomSum pointDiff |
	topSum _ bottomSum _ 0.0.
	1 to: nSamples do:
		[:i |  pointDiff _ (samples at: i) - (otherData at: i).
		topSum _ topSum + (pointDiff * pointDiff).
		bottomSum _ bottomSum + ((otherData at: i) * (otherData at: i))].
	^ topSum / bottomSum