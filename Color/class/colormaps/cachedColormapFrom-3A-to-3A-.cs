cachedColormapFrom: sourceDepth to: destDepth
	"Return a cached colormap for mapping between the given depths. Always return a real colormap, not nil; this allows the client to get an identity colormap that can then be copied and modified to do color transformations."
	"Note: This method returns a shared, cached colormap to save time and space. Clients that need to modify a colormap returned by this method should make a copy and modify that!"
	"Note: The colormap cache may be cleared by evaluating 'Color shutDown'."

	| key newMap |
	key _ sourceDepth@destDepth.
	CachedColormaps == nil ifTrue: [CachedColormaps _ Dictionary new].
	^ CachedColormaps at: key ifAbsent: [
		newMap _ self computeColormapFrom: sourceDepth to: destDepth.
		CachedColormaps at: key put: newMap.
		((sourceDepth >= 16) and: [destDepth < 16]) ifTrue: [
			"can use the same map from both 16-bits and 32-bits to a given lesser depth"
			CachedColormaps at: 16@destDepth put: newMap.
			CachedColormaps at: 32@destDepth put: newMap].
		newMap].
