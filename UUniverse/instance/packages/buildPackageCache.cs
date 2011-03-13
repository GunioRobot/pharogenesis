buildPackageCache
	self packages do: [ :p | p cachedCopyFilename ].