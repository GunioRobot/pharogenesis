matrix2x3InvertPoint: m
	"Invert the pre-loaded argument point by the given matrix"
	| x y det detX detY |
	self var: #m declareC:'float *m'.
	self var: #x declareC:'double x'.
	self var: #y declareC:'double y'.
	self var: #det declareC:'double det'.
	self var: #detX declareC:'double detX'.
	self var: #detY declareC:'double detY'.

	x _ m23ArgX - (m at: 2).
	y _ m23ArgY - (m at: 5).
	det _ ((m at: 0) * (m at: 4)) - ((m at: 1) * (m at: 3)).
	det = 0.0 ifTrue:[^interpreterProxy primitiveFail]."Matrix is singular."
	det _ 1.0 / det.
	detX _ (x * (m at: 4)) - ((m at: 1) * y).
	detY _ ((m at: 0) * y) - (x * (m at: 3)).
	m23ResultX _ detX * det.
	m23ResultY _ detY * det.