removeFromViewerCache: aPlayer
	viewerCache ifNotNil:
		[viewerCache removeKey: aPlayer ifAbsent: []]