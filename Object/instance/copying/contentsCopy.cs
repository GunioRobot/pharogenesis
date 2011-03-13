contentsCopy
	"Squeak: the receiver, serving as the contents of a Squeak object, wishes to have a suitable copy returned.  For most possible contents, the shallow is right; for a collection, i.e. for Folder contents, it is handled in a special-case way.  For alias-valued objects, we come to the crux: the receiver, rather than a copy thereof, must be returned.  6/6/96 sw"

	^ self shallowCopy release