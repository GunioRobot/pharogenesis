veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  See DeepCopier class comment."

	super veryDeepInner: deepCopier.
	project _ project.		"Weakly copied"
	lastProjectThumbnail _ lastProjectThumbnail veryDeepCopyWith: deepCopier.
	mouseDownTime _ nil.