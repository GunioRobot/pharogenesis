veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"objectToView _ objectToView.		Weakly copied"
viewSelector _ viewSelector veryDeepCopyWith: deepCopier.
lastSketchForm _ lastSketchForm veryDeepCopyWith: deepCopier.
lastFormShown _ lastFormShown veryDeepCopyWith: deepCopier.