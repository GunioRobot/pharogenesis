openInWorldExtent: extent
	"This msg and its callees result in the window being activeOnlyOnTop"
	Smalltalk isMorphic ifFalse: [^ self openInMVCExtent: extent].
	self openInWorld: World extent: extent