from: startVector to: endVector
	"Create a rotation from startVector to endVector"
	| axis cos sin |
	axis := startVector cross: endVector.
	cos := (startVector dot: endVector) arcCos.
	sin := axis length.
	axis safelyNormalize.
	self a: cos b: axis x * sin c: axis y * sin d: axis z * sin. 