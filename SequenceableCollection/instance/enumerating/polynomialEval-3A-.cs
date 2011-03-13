polynomialEval: thisX
	| sum valToPower |
	"Treat myself as the coeficients of a polynomial in X.  Evaluate it with thisX.  First element is the constant and last is the coeficient for the highest power."
	"  #(1 2 3) polynomialEval: 2   "   "is 3*X^2 + 2*X + 1 with X = 2"

	sum _ self first.
	valToPower _ thisX.
	2 to: self size do: [:ind | 
		sum _ sum + ((self at: ind) * valToPower).
		valToPower _ valToPower * thisX].
	^ sum