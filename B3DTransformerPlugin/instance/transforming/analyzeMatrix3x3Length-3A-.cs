analyzeMatrix3x3Length: m
	"Check if the matrix scales normals to non-unit length."
	| det |
	self var: #m declareC:'float *m'.
	self var: #det declareC:'double det'.
	det _ 	((m at: 0) * (m at: 5) * (m at: 10)) -
			((m at: 2) * (m at: 5) * (m at: 8)) + 
			((m at: 4) * (m at: 9) * (m at: 2)) - 
			((m at: 6) * (m at: 9) * (m at: 0)) +
			((m at: 8) * (m at: 1) * (m at: 6)) -
			((m at: 10) * (m at: 1) * (m at: 4)).
	^det < 0.99 or:[det > 1.01]