veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"target _ target.		Weakly copied"
"actionSelector _ actionSelector.		a Symbol"
"arguments _ arguments.		All weakly copied"
actWhen _ actWhen veryDeepCopyWith: deepCopier.
"oldColor _ oldColor veryDeepCopyWith: deepCopier."
visibleMorph _ visibleMorph.	"I guess this will have been copied already if needed"
delayBetweenFirings _ delayBetweenFirings.
mouseDownHaloColor _ mouseDownHaloColor.
stateCostumes _ stateCostumes veryDeepCopyWith: deepCopier.
currentLook _ currentLook.