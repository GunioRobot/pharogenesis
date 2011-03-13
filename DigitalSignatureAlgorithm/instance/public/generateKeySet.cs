generateKeySet
	"Generate and answer a key set for DSA. The result is a pair (<private key><public key>). Each key is an array of four large integers. The private key is (p, q, g, x); the public one is (p, q, g, y). The signer must be sure to record (p, q, g, x), and must keep x secret to prevent someone from forging their signature."
	"Note: Key generation can take some time. Open a transcript so you can see what's happening and take a coffee break!"

	| qAndPandS q p exp g h x y |
	qAndPandS _ self generateQandP.
	Transcript show: 'Computing g...'.
	q _ qAndPandS first.
	p _ qAndPandS second.
	exp _ (p - 1) / q.
	h _ 2.
	[g _ h raisedTo: exp modulo: p. g = 1] whileTrue: [h _ h + 1].
	Transcript show: 'done.'; cr.
	Transcript show: 'Computing x and y...'.
	x _ self nextRandom160.
	y _ g raisedTo: x modulo: p.
	Transcript show: 'done.'; cr.
	Transcript show: 'Key generation complete!'; cr.
	^ Array
		with: (Array with: p with: q with: g with: x)
		with: (Array with: p with: q with: g with: y)
