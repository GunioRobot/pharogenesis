veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
scriptName _ scriptName veryDeepCopyWith: deepCopier.
firstTileRow _ firstTileRow veryDeepCopyWith: deepCopier.
timeStamp _ timeStamp veryDeepCopyWith: deepCopier.
playerScripted _ playerScripted.		"Weakly copied"
handWithTile _ handWithTile.  "Just a cache"