transformPosition: aVector3
	| pVtx |
	pVtx _ B3DPrimitiveVertex new.
	pVtx position: aVector3.
	self privateTransformPrimitiveVertex: pVtx byModelView: self modelViewMatrix.
	^pVtx position