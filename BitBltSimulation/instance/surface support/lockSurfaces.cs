lockSurfaces
	"Get a pointer to the bits of any OS surfaces."

	"Note: The VM support code must robustly handle multiple attempts to lock
	the same surface and return the same values since one might blt just a portion
	of the surface from one location to another (see below; ioLockSurfaceBits()
	is called twice if sourceForm == destForm)."

	"Note: It is possible to query for the actual regions (e.g., after clipping)
	that might be affected by the BB operation during ioLockSurfaceBits since
	clipping is always performed before ioLockSurfaceBits is called. This
	might an improvement on some platforms (e.g., Unix w/ X-Windows) where
	getting actual bits requires a round-trip to the server. Right now we don't
	have accessors for these values (basically sx, sy, dx, dy, bbW, and bbH)
	but it would be trivial to add them -- iff somebody is interested..."
	"ar 10/20/1999: Just noted that the above is not true for scanCharacters..."

	"ar 10/19/1999: This *should* be inlined but how do we pass a pointer to the pitch
	of the surfaces in this case?!"

	| surfaceHandle |
	self inline: true. "If the CCodeGen learns how to inline #cCode: methods"
	hasSurfaceLock _ false.
	destBits == 0 ifTrue:["Blitting *to* OS surface"
		surfaceHandle _ interpreterProxy fetchInteger: FormBitsIndex ofObject: destForm.
		"destBits _ self cCode: 'ioLockSurfaceBits(surfaceHandle, &destPitch)'."
		hasSurfaceLock _ true.
	].
	(sourceBits == 0 and:[noSource not]) ifTrue:["Blitting *from* OS surface"
		surfaceHandle _ interpreterProxy fetchInteger: FormBitsIndex ofObject: sourceForm.
		"sourceBits _ self cCode:'ioLockSurfaceBits(surfaceHandle, &sourcePitch)'."
		hasSurfaceLock _ true.
	].
	^destBits ~~ 0 and:[sourceBits ~~ 0 or:[noSource]].