addShimmer
	"Add shimmer (random voicing amplitude perturbation)."
	self returnTypeC: 'void'.
	x1 _ x1 + (self nextRandom - 32767 * (frame at: Shimmer) / 32768.0 * x1).
	"x1 must be <= 0"
	x1 > 0 ifTrue: [x1 _ 0]