recordMorphFill: id matrix1: matrix1 ramp1: ramp1 matrix2: matrix2 ramp2: ramp2 linear: isLinear
	self recordGradientFill: id matrix: matrix2 ramp: ramp2 linear: isLinear.
	morphedFillStyles at: id put: (fillStyles at: id).
	self recordGradientFill: id matrix: matrix1 ramp: ramp1 linear: isLinear.	