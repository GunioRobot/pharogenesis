removeKeyNoBecome: key

	"The interpreter might be using this MethodDict while
	this method is running!  Therefore we perform the removal
	in a copy, and then return the copy for subsequent installation"

	| copy |
	copy _ self copy.
	copy removeDangerouslyKey: key ifAbsent: [^ self].
	^copy