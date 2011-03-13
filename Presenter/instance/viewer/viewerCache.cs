viewerCache
	viewerCache ifNil: [viewerCache _ IdentityDictionary new].
	^ viewerCache