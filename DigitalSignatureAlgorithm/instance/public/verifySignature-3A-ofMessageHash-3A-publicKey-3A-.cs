verifySignature: aSignature ofMessageHash: hash publicKey: publicKey
	"Answer true if the given signature is the authentic signature of the given message hash. That is, if the signature must have been computed using the private key set corresponding to the given public key. The public key is an array of four large integers: (p, q, g, y)."

	| p q g y r s w u1 u2 v0 v |
	p _ publicKey first.
	q _ publicKey second.
	g _ publicKey third.
	y _ publicKey fourth.
	r _ aSignature first.
	s _ aSignature last.
	((r > 0) and: [r < q]) ifFalse: [^ false].  "reject"
	((s > 0) and: [s < q]) ifFalse: [^ false].  "reject"

	w _ self inverseOf: s mod: q.
	u1 _ (hash * w) \\ q.
	u2 _ (r * w) \\ q.
	v0 _ (g raisedTo: u1 modulo: p) * (y raisedTo: u2 modulo: p).
	v _ ( v0 \\ p) \\ q.
	^ v = r
