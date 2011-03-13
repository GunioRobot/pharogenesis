flushViewerCache
	super flushViewerCache.
	associatedMorph standardPalette ifNotNil: [associatedMorph standardPalette showNoPalette]