uncoveredAt: aPoint
	"Return true if the receiver is not covered by any submorphs at the given point."

	| morphsAbove |
	morphsAbove _ self world morphsAt: aPoint.
	^ morphsAbove first = self or:
	 [(morphsAbove first isKindOf: HaloMorph) and:
	 [(morphsAbove at: 2) = self]]
