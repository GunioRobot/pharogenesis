rotationCenter
	"Return the rotation center of the receiver. The rotation center defines the relative offset inside the receiver's bounds for locating the reference position."
	| refPos |
	refPos _ self referencePosition.
	^ (refPos - self bounds origin) / self bounds extent asFloatPoint