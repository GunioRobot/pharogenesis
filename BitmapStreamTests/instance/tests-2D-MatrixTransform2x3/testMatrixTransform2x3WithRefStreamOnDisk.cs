testMatrixTransform2x3WithRefStreamOnDisk
	array _ MatrixTransform2x3 new.
	1 to: 6 do: [ :i | array at: i put: self randomFloat ].
	self validateRefStreamOnDisk	