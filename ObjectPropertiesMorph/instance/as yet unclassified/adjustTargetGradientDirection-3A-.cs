adjustTargetGradientDirection: aFractionalPoint

	| fs p |

	(fs _ myTarget fillStyle) isGradientFill ifFalse: [^self].
	fs direction: (p _ (aFractionalPoint * myTarget extent) rounded).
	self showSliderFeedback: p.
	myTarget changed.
