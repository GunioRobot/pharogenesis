rotateBy: angle
	"Experimental -- rotate around the current up vector by angle degrees.
	Center at the target point."
	position _ (B3DMatrix4x4 rotatedBy: angle around: up centeredAt: target) localPointToGlobal: position.