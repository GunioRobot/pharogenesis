changeOffsetBy: aPoint

	| transform rounder roundPt |

	"improve behavior at high magnification by rounding change to whole source pixels"
	transform _ self myTransformMorph.
	rounder _ [ :val |
		"(val abs + (transform scale * 0.99) roundTo: transform scale) * val sign"
		"looks like rounding wasn't a good solution"
		val
	].
	roundPt _ (rounder value: aPoint x) @ (rounder value: aPoint y).

	self changeOffsetTo: transform offset + roundPt.
