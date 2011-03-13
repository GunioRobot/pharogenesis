cameraPoint: newPt

	| transform |

	transform _ self myTransformMorph.
	self changeOffsetTo: newPt * transform scale - (transform innerBounds extent // 2) 

