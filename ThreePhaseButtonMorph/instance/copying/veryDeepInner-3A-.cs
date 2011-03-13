veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
offImage := offImage veryDeepCopyWith: deepCopier.
pressedImage := pressedImage veryDeepCopyWith: deepCopier.
state := state veryDeepCopyWith: deepCopier.
"target := target.		Weakly copied"
"actionSelector := actionSelector.		Symbol"
"arguments := arguments.		Weakly copied"
actWhen := actWhen.		"Symbol"