localBounds: newBounds

	localBounds := newBounds.
	bounds := (self position extent: newBounds extent // 20).
	transform := MatrixTransform2x3 
					transformFromLocal: newBounds 
					toGlobal: bounds