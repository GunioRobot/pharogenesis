veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"target _ target.		Weakly copied"
"arguments _ arguments.		All weakly copied"
minVal _ minVal veryDeepCopyWith: deepCopier.		"will be fast if integer"
maxVal _ maxVal veryDeepCopyWith: deepCopier.
truncate _ truncate veryDeepCopyWith: deepCopier.
