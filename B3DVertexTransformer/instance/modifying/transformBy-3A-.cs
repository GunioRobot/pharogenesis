transformBy: aTransformation
	self privateTransformMatrix: currentMatrix 
			with: aTransformation asMatrix4x4 
			into: currentMatrix.
	needsUpdate := true.