computeSignatureForMessageHash: hash privateKey: privateKey
	"Answer the digital signature of the given message hash using the given private key. A signature is a pair of large integers. The private key is an array of four large integers: (p, q, g, x)."

	| p q g x r s k tmp |
	p _ privateKey first.
	q _ privateKey second.
	g _ privateKey third.
	x _ privateKey fourth.

	r _ s _ 0.
	[r = 0 or: [s = 0]] whileTrue: [
		k _ self nextRandom160 \\ q.
		r _ (g raisedTo: k modulo: p) \\ q.
		tmp _ (hash + (x * r)) \\ q.
		s _ ((self inverseOf: k mod: q) * tmp) \\ q].

	^ Array with: r with: s
