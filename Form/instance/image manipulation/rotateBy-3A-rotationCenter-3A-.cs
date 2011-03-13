rotateBy: deg rotationCenter: aPoint
	"Rotate the receiver by the indicated number of degrees.  This variant gets a rotation center, but in fact ignores the thing -- awaiting someone's doing the right thing.   8/9/96 sw
	Note that rotationCenter should now be easy to include in the offset of the resulting form -- see <Point> rotateBy: angle about: center.  Could be even faster by sharing the sin, cos inside rotateBy:.  This should really be reversed so that this becomes the workhorse, and rotateBy: calls this with rotationCenter: self boundingBox center.  And while we're at it, why not include scaling?  9/19/96 di "

	^ self rotateBy: deg