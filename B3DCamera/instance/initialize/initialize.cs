initialize
	position := B3DVector3 x: 0.0 y: 0.0 z: 1.0.
	target := B3DVector3 x: 0.0 y: 0.0 z: 0.0.
	up := B3DVector3 x: 0.0 y: 1.0 z: 0.0.
	perspective := B3DCameraPerspective new.
	self fov: 45.0.
	self aspectRatio: 1.0.
	self nearDistance: 0.0001.
	self farDistance: 10000.0.