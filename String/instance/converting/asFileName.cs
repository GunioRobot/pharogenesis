asFileName
	"Answer a String made up from the receiver that is an acceptable file 
	name."

	^FileDirectory checkName: self fixErrors: true