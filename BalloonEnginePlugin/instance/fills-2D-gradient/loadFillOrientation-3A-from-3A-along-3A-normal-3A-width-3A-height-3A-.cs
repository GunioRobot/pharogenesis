loadFillOrientation: fill from: point1 along: point2 normal: point3 width: fillWidth height: fillHeight
	"Transform the points"
	| dirX dirY nrmX nrmY dsLength2 dsX dsY dtLength2 dtX dtY |
	self var: #point1 declareC:'int *point1'.
	self var: #point2 declareC:'int *point2'.
	self var: #point3 declareC:'int *point3'.

	point2 at: 0 put: (point2 at: 0) + (point1 at: 0).
	point2 at: 1 put: (point2 at: 1) + (point1 at: 1).
	point3 at: 0 put: (point3 at: 0) + (point1 at: 0).
	point3 at: 1 put: (point3 at: 1) + (point1 at: 1).
	self transformPoint: point1.
	self transformPoint: point2.
	self transformPoint: point3.
	dirX _ (point2 at: 0) - (point1 at: 0).
	dirY _ (point2 at: 1) - (point1 at: 1).
	nrmX _ (point3 at: 0) - (point1 at: 0).
	nrmY _ (point3 at: 1) - (point1 at: 1).

	"Compute the scale from direction/normal into ramp size"
	dsLength2 _ (dirX * dirX) + (dirY * dirY).
	dsLength2 > 0 ifTrue:[
		dsX _ (dirX asFloat * fillWidth asFloat * 65536.0 / dsLength2 asFloat) asInteger.
		dsY _ (dirY asFloat * fillWidth asFloat * 65536.0 / dsLength2 asFloat) asInteger.
	] ifFalse:[ dsX _ 0. dsY _ 0].
	dtLength2 _ (nrmX * nrmX) + (nrmY * nrmY).
	dtLength2 > 0 ifTrue:[
		dtX _ (nrmX asFloat * fillHeight asFloat * 65536.0 / dtLength2 asFloat) asInteger.
		dtY _ (nrmY asFloat * fillHeight asFloat * 65536.0 / dtLength2 asFloat) asInteger.
	] ifFalse:[dtX _ 0. dtY _ 0].
	self fillOriginXOf: fill put: (point1 at: 0).
	self fillOriginYOf: fill put: (point1 at: 1).
	self fillDirectionXOf: fill put: dsX.
	self fillDirectionYOf: fill put: dsY.
	self fillNormalXOf: fill put: dtX.
	self fillNormalYOf: fill put: dtY.
