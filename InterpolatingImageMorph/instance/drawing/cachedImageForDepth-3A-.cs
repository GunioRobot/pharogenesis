cachedImageForDepth: aDepth
	(cachedImage ~~ nil and:[cachedImage depth = aDepth])
		ifTrue:[^cachedImage].
	cachedImage _ nil. "In case we need some space"
	cachedImage _ Form extent: self bounds extent depth: aDepth.
	self drawImage: image on: (cachedImage getCanvas).
	^cachedImage