computeIntersectionOf: frontFace with: backFace at: yValue ifError: errorValue
	"Compute the z intersection at the given y value"
	| dx1 dz1 dx2 dz2 px pz det det2 |
	dx1 _ frontFace rightEdge xValue - frontFace leftEdge xValue.
	dz1 _ frontFace rightEdge zValue - frontFace leftEdge zValue.
	dx2 _ backFace rightEdge xValue - backFace leftEdge xValue.
	dz2 _ backFace rightEdge zValue - backFace leftEdge zValue.
	px _ backFace leftEdge xValue - frontFace leftEdge xValue.
	pz _ backFace leftEdge zValue - frontFace leftEdge zValue.
	"Solve the linear equation using cramers rule"
	det _ (dx1 * dz2) - (dx2 * dz1).
	det = 0.0 ifTrue:[^errorValue].
	"det1 _ (dx1 * pz) - (px * dz1)."
	det2 _ (px * dz2) - (pz * dx2).
	"det1 _ det1 / det."
	det2 _ det2 / det.
	^frontFace leftEdge xValue + (dx1 * det2) truncated