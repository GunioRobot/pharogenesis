reset
	"Fill the ring with random noise."

	| seed n |
	super reset.
	seed _ 17.
	n _ ring monoSampleCount.
	1 to: n do: [:i |
		seed _ ((seed * 1309) + 13849) bitAnd: 65535.
		ring at: i put: seed - 32768].
	count _ initialCount.
	scaledIndex _ ScaleFactor.
