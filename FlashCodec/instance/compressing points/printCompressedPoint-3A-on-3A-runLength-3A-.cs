printCompressedPoint: aPoint on: aStream runLength: n
	"Print the given point on the stream using the given run length"
	n = 0 ifTrue:[^self]. "Can only happen for the first run"
	"Check if we're storing a zero point"
	(aPoint x = 0 and:[aPoint y = 0]) 
		ifTrue:[
			"Two zero points are specially encoded since they
			occur if a line segment ends and the next segment
			starts from its end point, e.g., (p1,p2,p2) (p2,p3,p4) - this is very likely."
			n = 2 ifTrue:[^aStream nextPut:$A].
			n = 1 ifTrue:[^aStream nextPut: $Z].
			^aStream nextPut:$*; print: n; nextPut:$Z].

	n > 1 ifTrue:[
		"Run length encoding: '*N' repeat the following point n times"
		aStream nextPut: $*; print: n].
	"Point encoding: Two numbers.
	Number encoding: '+XYZ' or '-XYZ'"
	self printPoint: aPoint on: aStream