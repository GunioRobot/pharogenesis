rotateFrom: anOldPoint to: aCurrentPoint
	| camera matrix anOldPointOnSphere aCurrentPointOnSphere center radius |
	center := self bounds center.
	radius := self bounds extent r / 2. 
	anOldPointOnSphere := self pointOnSphereCentered: center radius: radius atPoint: anOldPoint.
	aCurrentPointOnSphere := self pointOnSphereCentered: center radius: radius atPoint: aCurrentPoint.
	camera := scene defaultCamera.
	matrix := B3DMatrix4x4
		rotatedBy: ((anOldPointOnSphere dot: aCurrentPointOnSphere) min: 1.0) arcCos radiansToDegrees
		around:
			(camera asMatrix4x4 inverseTransformation localPointToGlobal:
				(anOldPointOnSphere cross: aCurrentPointOnSphere)) - camera position
		centeredAt: camera target.
	camera position: (matrix localPointToGlobal: camera position).
	camera up: (matrix localPointToGlobal: camera up).
	self updateHeadlight.
	self changed.