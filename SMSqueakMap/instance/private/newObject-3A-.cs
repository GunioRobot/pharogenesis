newObject: anSMObject 
	"Add an SMObject to me. Clear the valid caches."

	self addDirty: anSMObject.
	self clearCachesFor: anSMObject.
	^objects at: anSMObject id put: anSMObject