findPlatformsPath
	| dir |
	dir _ FileList2 modalFolderSelector.
	dir ifNil: [^nil].
	self platformsPathText: dir pathName