transformMatrix: src with: arg into: dst
	"Transform src with arg into dst.
	It is allowed that src == dst but not arg == dst"
	| m1 m2 m3 c1 c2 c3 c4 |
	self var: #src declareC:'float *src'.
	self var: #arg declareC:'float *arg'.
	self var: #dst declareC:'float *dst'.
	self var: #m1 declareC:'float *m1'.
	self var: #m2 declareC:'float *m2'.
	self var: #m3 declareC:'float *m3'.
	self var: #c1 declareC:'float c1'.
	self var: #c2 declareC:'float c2'.
	self var: #c3 declareC:'float c3'.
	self var: #c4 declareC:'float c4'.

	m1 _ self cCoerce: src to:'float *'.
	m2 _ self cCoerce: arg to: 'float *'.
	m3 _ self cCoerce: dst to: 'float *'.

	0 to: 3 do:[:i|

		"Compute next row"
		c1 _ ((m1 at: 0) * (m2 at: 0)) + ((m1 at: 1) * (m2 at: 4)) +
				((m1 at: 2) * (m2 at: 8)) + ((m1 at: 3) * (m2 at: 12)).

		c2 _ ((m1 at: 0) * (m2 at: 1)) + ((m1 at: 1) * (m2 at: 5)) +
				((m1 at: 2) * (m2 at: 9)) + ((m1 at: 3) * (m2 at: 13)).

		c3 _ ((m1 at: 0) * (m2 at: 2)) + ((m1 at: 1) * (m2 at: 6)) +
				((m1 at: 2) * (m2 at: 10)) + ((m1 at: 3) * (m2 at: 14)).

		c4 _ ((m1 at: 0) * (m2 at: 3)) + ((m1 at: 1) * (m2 at: 7)) +
				((m1 at: 2) * (m2 at: 11)) + ((m1 at: 3) * (m2 at: 15)).

		"Store result"
		m3 at: 0 put: c1.
		m3 at: 1 put: c2.
		m3 at: 2 put: c3.
		m3 at: 3 put: c4.

		"Skip src and dst to next row"
		m1 _ m1 + 4.
		m3 _ m3 + 4.
	].
