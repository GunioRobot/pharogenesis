reset
	"Fill the ring with random noise."

	| seed |
	super reset.
	seed _ Time millisecondClockValue bitAnd: 65535.
	1 to: ringSize do: [ :i |
		seed _ ((seed * 1309) + 13849) bitAnd: 65535.
		ring at: i put: (((seed - 32768) * amplitude) bitShift: -10).
	].
	count _ initialCount.
	ringIndx _ 1.
