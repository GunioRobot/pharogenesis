nSamples: n nLevels: nLevs
	"Initialize a wavelet transform."
	"Note the sample array size must be N + 5, where N is a multiple of 2^nLevels"
	| dyadSize |
	(n // (1 bitShift: nLevs)) > 0 ifFalse: [self error: 'Data size error'].
	(n \\ (1 bitShift: nLevs)) = 0 ifFalse: [self error: 'Data size error'].
	nSamples _ n.
	samples _ Array new: n + 5.
	nLevels _ nLevs.
	transform _ Array new: nLevels*2.  "Transformed data is stored as a tree of coeffs"
	dyadSize _ nSamples.
	1 to: nLevels do:
		[:i |  dyadSize _ dyadSize // 2.
		transform at: 2*i-1 put: (Array new: dyadSize + 5).
		transform at: 2*i put: (Array new: dyadSize + 5)]