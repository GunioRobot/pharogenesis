invertPoint: aPoint
	"Transform aPoint from global coordinates into local coordinates"
	| x y det a11 a12 a21 a22 detX detY |
	x _ aPoint x asFloat - (self a13).
	y _ aPoint y asFloat - (self a23).
	a11 _ self a11.	a12 _ self a12.
	a21 _ self a21.	a22 _ self a22.
	det _ (a11 * a22) - (a12 * a21).
	det = 0.0 ifTrue:[^0@0]. "So we have at least a valid result"
	det _ 1.0 / det.
	detX _ (x * a22) - (a12 * y).
	detY _ (a11 * y) - (x * a21).
	^(detX * det) @ (detY * det)