computeFromNear: nearDistance far: farDistance fov: fieldOfView aspect: aspectRatio
	"Compute the viewing frustum from the given values"
	| top bottom |
	top := nearDistance * fieldOfView degreesToRadians tan.
	bottom := top negated.
	self left: bottom * aspectRatio.
	self right: top * aspectRatio.	
	self top: top.
	self bottom: bottom.
	self near: nearDistance.
	self far: farDistance.