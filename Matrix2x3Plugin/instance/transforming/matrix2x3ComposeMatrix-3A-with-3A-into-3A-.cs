matrix2x3ComposeMatrix: m1 with: m2 into: m3
	"Multiply matrix m1 with m2 and store the result into m3."
	| a11 a12 a13 a21 a22 a23 |
	self var: #m1 declareC:'const float *m1'.
	self var: #m2 declareC:'const float *m2'.
	self var: #m3 declareC:'float *m3'.

	self var: #a11 declareC:'double a11'.
	self var: #a12 declareC:'double a12'.
	self var: #a13 declareC:'double a13'.
	self var: #a21 declareC:'double a21'.
	self var: #a22 declareC:'double a22'.
	self var: #a23 declareC:'double a23'.

	a11 _ ((m1 at: 0) * (m2 at: 0)) + ((m1 at: 1) * (m2 at: 3)).
	a12 _ ((m1 at: 0) * (m2 at: 1)) + ((m1 at: 1) * (m2 at: 4)).
	a13 _ ((m1 at: 0) * (m2 at: 2)) + ((m1 at: 1) * (m2 at: 5)) + (m1 at: 2).
	a21 _ ((m1 at: 3) * (m2 at: 0)) + ((m1 at: 4) * (m2 at: 3)).
	a22 _ ((m1 at: 3) * (m2 at: 1)) + ((m1 at: 4) * (m2 at: 4)).
	a23 _ ((m1 at: 3) * (m2 at: 2)) + ((m1 at: 4) * (m2 at: 5)) + (m1 at: 5).

	m3 at: 0 put: (self cCoerce: a11 to: 'float').
	m3 at: 1 put: (self cCoerce: a12 to: 'float').
	m3 at: 2 put: (self cCoerce: a13 to: 'float').
	m3 at: 3 put: (self cCoerce: a21 to: 'float').
	m3 at: 4 put: (self cCoerce: a22 to: 'float').
	m3 at: 5 put: (self cCoerce: a23 to: 'float').
