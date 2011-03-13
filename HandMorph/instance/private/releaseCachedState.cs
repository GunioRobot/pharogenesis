releaseCachedState
	| oo ui |
	ui _ userInitials.
	super releaseCachedState.
	cacheCanvas _ nil.
	oo _ owner.
	self removeAllMorphs.
	self initialize.	"nuke everything"
	self privateOwner: oo.
	self releaseAllFoci.
	self userInitials: ui andPicture: (self userPicture).