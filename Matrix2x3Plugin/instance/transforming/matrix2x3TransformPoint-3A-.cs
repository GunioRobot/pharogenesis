matrix2x3TransformPoint: m
	"Transform the pre-loaded argument point by the given matrix"
	self var: #m declareC:'float *m'.
	m23ResultX _ (m23ArgX * (m at: 0)) + (m23ArgY * (m at: 1)) + (m at: 2).
	m23ResultY _ (m23ArgX * (m at: 3)) + (m23ArgY * (m at: 4)) + (m at: 5).