panBy: aPoint
	| camera pt |
	pt := B3DVector3 x: aPoint x y: aPoint y negated z: 0.0.
 	camera := scene defaultCamera.
	pt := pt * (camera direction length) / 200.

	pt := camera asMatrix4x4 inverseTransformation localPointToGlobal: pt.
	pt := pt - camera position.

	camera position: camera position + pt.
	camera target: camera target + pt.
	self changed.