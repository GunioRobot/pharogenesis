warpMapForDepth: destDepth withTransparentFor: bkgndColor
	(CachedWarpDepth = destDepth and: [CachedWarpColor = bkgndColor])
		ifTrue: ["Map is OK as is -- return it"
				^ CachedWarpMap].
	(CachedWarpMap == nil or: [CachedWarpDepth ~= destDepth])
		ifTrue: ["Have to recreate the map"
				CachedWarpMap _ Color computeColormapFrom: 32 to: destDepth.
				CachedWarpDepth _ destDepth]
		ifFalse: ["Map is OK, if we restore prior color substiution"
				CachedWarpMap at: (CachedWarpColor indexInMap: CachedWarpMap)
					put: (CachedWarpColor pixelValueForDepth: destDepth)].
	"Now map the background color into transparent, and return the new map"
	CachedWarpColor _ bkgndColor.
	CachedWarpMap at: (CachedWarpColor indexInMap: CachedWarpMap)
					put: 0.
	^ CachedWarpMap
