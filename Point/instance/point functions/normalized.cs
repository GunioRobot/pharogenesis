normalized
	"Optimized for speed -- ar 8/26/2001"
	| r |
	r := (x * x + (y * y)) sqrt.
	^ (x / r) @ (y / r)