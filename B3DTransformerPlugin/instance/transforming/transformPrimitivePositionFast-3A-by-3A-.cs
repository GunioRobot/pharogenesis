transformPrimitivePositionFast: pVertex by: matrix
	"Transform the position of the given primitive vertex assuming that 
	matrix a41 = a42 = a43 = 0.0 and a44 = 1.0"
	| x y z rx ry rz |
	self var: #pVertex declareC:'float *pVertex'.
	self var: #matrix declareC:'float *matrix'.
	self var: #x declareC:'double x'.
	self var: #y declareC:'double y'.
	self var: #z declareC:'double z'.
	self var: #rx declareC:'double rx'.
	self var: #ry declareC:'double ry'.
	self var: #rz declareC:'double rz'.

	x _ pVertex at: PrimVtxPositionX.
	y _ pVertex at: PrimVtxPositionY.
	z _ pVertex at: PrimVtxPositionZ.

	rx _ (x * (matrix at: 0)) + (y * (matrix at: 1)) + (z * (matrix at: 2)) + (matrix at: 3).
	ry _ (x * (matrix at: 4)) + (y * (matrix at: 5)) + (z * (matrix at: 6)) + (matrix at: 7).
	rz _ (x * (matrix at: 8)) + (y * (matrix at: 9)) + (z * (matrix at: 10)) + (matrix at: 11).

	pVertex at: PrimVtxPositionX put: (self cCoerce: rx to: 'float').
	pVertex at: PrimVtxPositionY put: (self cCoerce: ry to: 'float').
	pVertex at: PrimVtxPositionZ put: (self cCoerce: rz to: 'float').