markAndTraceMethodCacheLine: lineIndex
	| oldOop |
	self inline: true.

	oldOop		_ methodCache at: lineIndex + MethodCacheSelectorCol.
	oldOop ~= 0 ifTrue:
		[self markAndTrace: oldOop.
		 oldOop	_ methodCache at: lineIndex + MethodCacheClassCol.
		 self markAndTrace: oldOop.
		 oldOop	_ methodCache at: lineIndex + MethodCacheMethodCol.
		 self markAndTrace: oldOop.
		 oldOop	_ methodCache at: lineIndex + MethodCacheTMethodCol.
		 self markAndTrace: oldOop].
