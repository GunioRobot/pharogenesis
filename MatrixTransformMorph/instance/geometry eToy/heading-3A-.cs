heading: newHeading
	"Set the receiver's heading (in eToy terms)"
	self rotateBy: ((newHeading - self forwardDirection) - self innerAngle).