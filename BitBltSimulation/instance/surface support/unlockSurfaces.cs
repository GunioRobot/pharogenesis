unlockSurfaces
	"Unlock the bits of any OS surfaces."

	"Note: It is possible to query for the dirty rectangle from ioUnlockSurfaceBits()
	since the affected regions are set before this method is called. This is currently
	not part of the InterpreterProxy interface but one can query for affectedLeft(),
	affectedRight(), affectedTop(), and affectedBottom() if the surface support
	is compiled with the VM."

	| surfaceHandle |
	hasSurfaceLock ifTrue:[
		surfaceHandle _ interpreterProxy fetchPointer: FormBitsIndex ofObject: sourceForm.
		(interpreterProxy isIntegerObject: surfaceHandle) ifTrue:[
			surfaceHandle _ interpreterProxy integerValueOf: surfaceHandle.
			"self ioUnlockSurfaceBits: surfaceHandle."
			sourceBits _ sourcePitch _ 0.
		].
		surfaceHandle _ interpreterProxy fetchPointer: FormBitsIndex ofObject: destForm.
		(interpreterProxy isIntegerObject: surfaceHandle) ifTrue:[
			surfaceHandle _ interpreterProxy integerValueOf: surfaceHandle.
			"self ioUnlockSurfaceBits: surfaceHandle."
			destBits _ destPitch _ 0.
		].
		hasSurfaceLock _ false.
	].