initialiseModule
	self export: true.

	loadBBFn _ interpreterProxy ioLoadFunction: 'loadBitBltFrom' From: bbPluginName.
	copyBitsFn _ interpreterProxy ioLoadFunction: 'copyBitsFromtoat' From: bbPluginName.
	^(loadBBFn ~= 0 and:[copyBitsFn ~= 0])