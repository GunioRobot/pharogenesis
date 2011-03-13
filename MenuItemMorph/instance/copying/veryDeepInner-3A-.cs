veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
isEnabled _ isEnabled veryDeepCopyWith: deepCopier.
subMenu _ subMenu veryDeepCopyWith: deepCopier.
isSelected _ isSelected veryDeepCopyWith: deepCopier.
"target _ target.		Weakly copied"
"selector _ selector.		a Symbol"
arguments _ arguments.		"All weakly copied"