localBounds: newBounds

	localBounds _ newBounds.
	bounds _ (self position extent: newBounds extent // 20).
	transform _ MatrixTransform2x3 
					transformFromLocal: newBounds 
					toGlobal: bounds