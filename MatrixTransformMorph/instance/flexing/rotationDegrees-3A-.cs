rotationDegrees: degrees
	| last delta |
	last _ self lastRotationDegrees.
	delta _ degrees - last.
	self rotateBy: delta.
	self lastRotationDegrees: degrees.