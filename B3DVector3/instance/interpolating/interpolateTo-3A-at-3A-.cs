interpolateTo: end at: amountDone
	"Interpolates a new vector based on the instance vector, the end state vector, and the amount already done (between 0 and 1)."

	| tX tY tZ |
	tX _ self x.
	tY _ self y.
	tZ _ self z.

	^ (B3DVector3 x: (tX + (((end x) - tX) * amountDone))
				y: (tY + (((end y) - tY) * amountDone))
				z: (tZ + (((end z) - tZ) * amountDone))).
