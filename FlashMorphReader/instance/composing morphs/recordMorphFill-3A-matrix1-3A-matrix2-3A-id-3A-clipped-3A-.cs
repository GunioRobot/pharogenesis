recordMorphFill: id matrix1: matrix1 matrix2: matrix2 id: bmId clipped: aBool
	self recordBitmapFill: id matrix: matrix2 id: bmId clipped: aBool.
	morphedFillStyles at: id put: (fillStyles at: id).
	self recordBitmapFill: id matrix: matrix1 id: bmId clipped: aBool.