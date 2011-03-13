veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"defaultTarget _ defaultTarget.		Weakly copied"
selectedItem _ selectedItem veryDeepCopyWith: deepCopier.
stayUp _ stayUp veryDeepCopyWith: deepCopier.
popUpOwner _ popUpOwner.		"Weakly copied"
activeSubMenu _ activeSubMenu. "Weakly copied"
