transformPrimitiveNormal: pVertex by: matrix rescale: rescale
	"Transform the normal of the given primitive vertex"
	| x y z rx ry rz dot |
	self var: #pVertex declareC:'float *pVertex'.
	self var: #matrix declareC:'float *matrix'.
	self var: #x declareC:'double x'.
	self var: #y declareC:'double y'.
	self var: #z declareC:'double z'.
	self var: #rx declareC:'double rx'.
	self var: #ry declareC:'double ry'.
	self var: #rz declareC:'double rz'.
	self var: #dot declareC:'double dot'.

	x _ pVertex at: PrimVtxNormalX.
	y _ pVertex at: PrimVtxNormalY.
	z _ pVertex at: PrimVtxNormalZ.

	rx _ (x * (matrix at: 0)) + (y * (matrix at: 1)) + (z * (matrix at: 2)).
	ry _ (x * (matrix at: 4)) + (y * (matrix at: 5)) + (z * (matrix at: 6)).
	rz _ (x * (matrix at: 8)) + (y * (matrix at: 9)) + (z * (matrix at: 10)).

	rescale ifTrue:[
		dot _ (rx * rx) + (ry * ry) + (rz * rz).
		dot < 1.0e-20 
			ifTrue:[rx _ ry _ rz _ 0.0]
			ifFalse:[dot = 1.0 ifFalse:[dot _ 1.0 / dot sqrt.
									rx _ rx * dot. ry _ ry * dot. rz _ rz * dot]]].

	pVertex at: PrimVtxNormalX put: (self cCoerce: rx to:'float').
	pVertex at: PrimVtxNormalY put: (self cCoerce: ry to:'float').
	pVertex at: PrimVtxNormalZ put: (self cCoerce: rz to:'float').
