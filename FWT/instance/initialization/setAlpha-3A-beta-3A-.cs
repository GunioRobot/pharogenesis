setAlpha: alph beta: bet
	"Set alpha and beta, compute wavelet coeefs, and derive hFilter and lFilter"
	| tcosa tcosb tsina tsinb |
	alpha _ alph.
	beta _ bet.

	"WaveletCoeffs..."
	"precalculate cosine of alpha and sine of beta"
	tcosa _ alpha cos.
	tcosb _ beta cos.
	tsina _ alpha sin.
	tsinb _ beta sin.
	coeffs _ Array new: 6.
	
	"calculate first two wavelet coefficients a _ a(-2) and b _ a(-1)"
	coeffs at: 1 put: ((1.0 + tcosa + tsina) * (1.0 - tcosb - tsinb)
					+ (2.0 * tsinb * tcosa)) / 4.0.
	coeffs at: 2 put: ((1.0 - tcosa + tsina) * (1.0 + tcosb - tsinb)
					- (2.0 * tsinb * tcosa)) / 4.0.

	"precalculate cosine and sine of alpha minus beta"
	tcosa _ (alpha - beta) cos.
	tsina _ (alpha - beta) sin.

	"calculate last four wavelet coefficients c _ a(0), d _ a(1), e _ a(2), and f _ a(3)"
	coeffs at: 3 put: (1.0 + tcosa + tsina) / 2.0.
	coeffs at: 4 put: (1.0 + tcosa - tsina) / 2.0.
	coeffs at: 5 put: 1.0 - (coeffs at: 1) - (coeffs at: 3).
	coeffs at: 6 put: 1.0 - (coeffs at: 2) - (coeffs at: 4).

	"MakeFiltersFromCoeffs..."
	"Select the non-zero wavelet coefficients"
	coeffs _ coeffs copyFrom: (coeffs findFirst: [:c | c abs > 1.0e-14])
						to: (coeffs findLast: [:c | c abs > 1.0e-14]).

	"Form the low pass and high pass filters for decomposition"
	hTilde _ coeffs reversed collect: [:c | c / 2.0].
	gTilde _ coeffs collect: [:c | c / 2.0].
	1 to: gTilde size by: 2 do:
		[:i | gTilde at: i put: (gTilde at: i) negated].

	"Form the low pass and high pass filters for reconstruction"
	h _ coeffs copy.
	g _ coeffs reversed.
	2 to: g size by: 2 do:
		[:i | g at: i put: (g at: i) negated]
