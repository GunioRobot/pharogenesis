veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"defaultTarget _ defaultTarget.		Weakly copied"
lastSelection _ lastSelection veryDeepCopyWith: deepCopier.
stayUp _ stayUp veryDeepCopyWith: deepCopier.
originalEvent _ originalEvent veryDeepCopyWith: deepCopier.
popUpOwner _ popUpOwner.		"Weakly copied"