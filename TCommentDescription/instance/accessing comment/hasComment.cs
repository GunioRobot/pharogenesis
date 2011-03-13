hasComment
	"return whether this class truly has a comment other than the default"
	| org |
	org _ self instanceSide organization.
	^org classComment isEmptyOrNil not