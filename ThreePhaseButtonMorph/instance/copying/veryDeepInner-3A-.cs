veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
offImage _ offImage veryDeepCopyWith: deepCopier.
pressedImage _ pressedImage veryDeepCopyWith: deepCopier.
state _ state veryDeepCopyWith: deepCopier.
"target _ target.		Weakly copied"
"actionSelector _ actionSelector.		Symbol"
"arguments _ arguments.		Weakly copied"
actWhen _ actWhen.		"Symbol"