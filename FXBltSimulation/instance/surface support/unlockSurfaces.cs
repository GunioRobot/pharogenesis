unlockSurfaces
	"Unlock the bits of any OS surfaces."
	"See the comment in lockSurfaces. Similar rules apply. That is, the area provided in ioUnlockSurface can be used to determine the dirty region after drawing. If a source is unlocked, then the area will be (0,0,0,0) to indicate that no portion is dirty."
	| sourceHandle destHandle destLocked fn |
	self var: #fn declareC:'int (*fn)(int, int, int, int, int)'.
	hasSurfaceLock ifTrue:[
		unlockSurfaceFn = 0 ifTrue:[self loadSurfacePlugin ifFalse:[^nil]].
		fn _ self cCoerce: unlockSurfaceFn to: 'int (*)(int, int, int, int, int)'.
		destLocked _ false.
		destHandle _ interpreterProxy fetchPointer: FormBitsIndex ofObject: destForm.
		(interpreterProxy isIntegerObject: destHandle) ifTrue:[
			destHandle _ interpreterProxy integerValueOf: destHandle.
			"The destBits are always assumed to be dirty"
			self cCode:'fn(destHandle, affectedL, affectedT, affectedR-affectedL, affectedB-affectedT)'.
			destBits _ destPitch _ 0.
			destLocked _ true.
		].
		noSource ifFalse:[
			sourceHandle _ interpreterProxy fetchPointer: FormBitsIndex ofObject: sourceForm.
			(interpreterProxy isIntegerObject: sourceHandle) ifTrue:[
				sourceHandle _ interpreterProxy integerValueOf: sourceHandle.
				"Only unlock sourceHandle if different from destHandle"
				(destLocked and:[sourceHandle = destHandle]) 
					ifFalse:[self cCode: 'fn(sourceHandle, 0, 0, 0, 0)'].
				sourceBits _ sourcePitch _ 0.
			].
		].
		hasSurfaceLock _ false.
	].