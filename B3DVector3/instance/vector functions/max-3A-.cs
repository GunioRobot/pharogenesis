max: aVector
	^B3DVector3 
		x: (self x max: aVector x)
		y: (self y max: aVector y)
		z: (self z max: aVector z)