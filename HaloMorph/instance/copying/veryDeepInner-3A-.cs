veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

	super veryDeepInner: deepCopier.
	"target _ target.		Weakly copied"
	"innerTarget _ innerTarget.		Weakly copied"
	positionOffset _ positionOffset veryDeepCopyWith: deepCopier.
	angleOffset _ angleOffset veryDeepCopyWith: deepCopier.
	growingOrRotating _ growingOrRotating veryDeepCopyWith: deepCopier.
	directionArrowAnchor _ directionArrowAnchor.
	simpleMode _ simpleMode.
	haloBox _ haloBox.
	originalExtent _ originalExtent
