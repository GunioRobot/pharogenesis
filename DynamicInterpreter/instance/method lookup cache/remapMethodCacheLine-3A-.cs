remapMethodCacheLine: lineIndex
	| oldOop |
	self inline: true.

	oldOop _ methodCache at:		lineIndex + MethodCacheSelectorCol.
	oldOop ~= 0 ifTrue:
		[methodCache at:			lineIndex + MethodCacheSelectorCol	put: (self remap: oldOop).

		oldOop _ methodCache at:	lineIndex + MethodCacheClassCol.
		methodCache at:				lineIndex + MethodCacheClassCol		put: (self remap: oldOop).

		oldOop _ methodCache at:	lineIndex + MethodCacheMethodCol.
		methodCache at:				lineIndex + MethodCacheMethodCol	put: (self remap: oldOop).

		oldOop _ methodCache at:	lineIndex + MethodCacheTMethodCol.
		methodCache at:				lineIndex + MethodCacheTMethodCol	put: (self remap: oldOop)].
