dotProductOfFloat: v1 withDouble: v2
	self var: #v1 declareC:'float * v1'.
	self var: #v2 declareC:'double *v2'.
	self returnTypeC:'double'.
	^((v1 at: 0) * (v2 at: 0)) +
		((v1 at: 1) * (v2 at: 1)) +
			((v1 at: 2) * (v2 at: 2)).
