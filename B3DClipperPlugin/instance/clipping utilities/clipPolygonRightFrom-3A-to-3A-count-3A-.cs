clipPolygonRightFrom: buf1 to: buf2 count: n
	| last next t outIndex inLast inNext |
	self var: #buf1 declareC:'int *buf1'.
	self var: #buf2 declareC:'int *buf2'.
	self var: #last declareC:'int *last'.
	self var: #next declareC:'int *next'.
	self var: #t declareC: 'double t'.
	outIndex _ 0.
	last _ buf1 + (n * PrimVertexSize).
	next _ buf1 + PrimVertexSize.
	inLast _ (last at: PrimVtxClipFlags) anyMask: InRightBit.
	1 to: n do:[:i|
		inNext _ (next at: PrimVtxClipFlags) anyMask: InRightBit.
		inLast = inNext ifFalse:["Passes clip boundary"
			t _ self rightClipValueFrom: last to: next.
			outIndex _ outIndex + 1.
			self interpolateFrom: (self cCoerce: last to:'float *')
				to: (self cCoerce: next to:'float *')
				at: t 
				into: (self cCoerce: (buf2 + (outIndex * PrimVertexSize)) to:'float*')].
		inNext ifTrue:[
			outIndex _ outIndex+1.
			0 to: PrimVertexSize-1 do:[:j|
				buf2 at: (outIndex*PrimVertexSize + j) put: (next at: j)].
		].
		last _ next.
		inLast _ inNext.
		next _ next + PrimVertexSize.
	].
	^outIndex