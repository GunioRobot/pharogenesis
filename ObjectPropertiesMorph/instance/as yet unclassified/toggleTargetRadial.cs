toggleTargetRadial

	| fs |

	(fs _ myTarget fillStyle) isGradientFill ifFalse: [^self].
	fs radial: fs radial not.
	myTarget changed.
	self doEnables.