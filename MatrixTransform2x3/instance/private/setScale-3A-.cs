setScale: aPoint
	"Set the raw scale in the receiver"
	| pt |
	pt _ aPoint asPoint.
	self a11: pt x asFloat.
	self a22: pt y asFloat.