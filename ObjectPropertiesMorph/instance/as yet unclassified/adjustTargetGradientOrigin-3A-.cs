adjustTargetGradientOrigin: aFractionalPoint

	| fs p |

	(fs _ myTarget fillStyle) isGradientFill ifFalse: [^self].
	fs origin: (p _ myTarget topLeft + (aFractionalPoint * myTarget extent) rounded).
	self showSliderFeedback: p.
	myTarget changed.
