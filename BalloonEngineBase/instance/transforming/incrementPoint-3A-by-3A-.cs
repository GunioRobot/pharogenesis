incrementPoint: point by: delta
	self var: #point declareC:'int *point'.
	point at: 0 put: (point at: 0) + delta.
	point at: 1 put: (point at: 1) + delta.