initializeHammingWindow: alpha
	"Initialize the windowing function to the generalized Hamming window. See F. Richard Moore, Elements of Computer Music, p. 100. An alpha of 0.54 gives the Hamming window, 0.5 gives the hanning window."

	| v midPoint |
	window _ FloatArray new: n.
	midPoint _ (n + 1) / 2.0.
	1 to: n do: [:i |
		v _ alpha + ((1.0 - alpha) * (2.0 * Float pi * ((i - midPoint) / n)) cos).
		window at: i put: v].

