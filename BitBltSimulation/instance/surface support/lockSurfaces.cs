lockSurfaces
	"Get a pointer to the bits of any OS surfaces."
	"Notes: 
	* For equal source/dest handles only one locking operation is performed.
	This is to prevent locking of overlapping areas which does not work with
	certain APIs (as an example, DirectDraw prevents locking of overlapping areas). 
	A special case for non-overlapping but equal source/dest handle would 
	be possible but we would have to transfer this information over to 
	unlockSurfaces somehow (currently, only one unlock operation is 
	performed for equal source and dest handles). Also, this would require
	a change in the notion of ioLockSurface() which is right now interpreted
	as a hint and not as a requirement to lock only the specific portion of
	the surface.

	* The arguments in ioLockSurface() provide the implementation with
	an explicit hint what area is affected. It can be very useful to
	know the max. affected area beforehand if getting the bits requires expensive
	copy operations (e.g., like a roundtrip to the X server or a glReadPixel op).
	However, the returned pointer *MUST* point to the virtual origin of the surface
	and not to the beginning of the rectangle. The promise made by BitBlt
	is to never access data outside the given rectangle (aligned to 4byte boundaries!)
	so it is okay to return a pointer to the virtual origin that is actually outside
	the valid memory area.

	* The area provided in ioLockSurface() is already clipped (e.g., it will always
	be inside the source and dest boundingBox) but it is not aligned to word boundaries
	yet. It is up to the support code to compute accurate alignment if necessary.

	* Warping always requires the entire source surface to be locked because
	there is no beforehand knowledge about what area will actually be traversed.

	"
	| sourceHandle destHandle l r t b fn |
	self inline: true. "If the CCodeGen learns how to inline #cCode: methods"
	self var: #fn declareC:'int (*fn)(int, int*, int, int, int, int)'.
	hasSurfaceLock _ false.
	destBits = 0 ifTrue:["Blitting *to* OS surface"
		lockSurfaceFn = 0 ifTrue:[self loadSurfacePlugin ifFalse:[^nil]].
		fn _ self cCoerce: lockSurfaceFn to: 'int (*)(int, int*, int, int, int, int)'.
		destHandle _ interpreterProxy fetchInteger: FormBitsIndex ofObject: destForm.
		(sourceBits = 0 and:[noSource not]) ifTrue:[
			sourceHandle _ interpreterProxy fetchInteger: FormBitsIndex ofObject: sourceForm.
			"Handle the special case of equal source and dest handles"
			(sourceHandle = destHandle) ifTrue:[
				"If we have overlapping source/dest we lock the entire area
				so that there is only one area transmitted"
				isWarping ifFalse:[
					"When warping we always need the entire surface for the source"
					sourceBits _ self cCode:'fn(sourceHandle, &sourcePitch, 0,0, sourceWidth, sourceHeight)'.
				] ifTrue:[
					"Otherwise use overlapping area"
					l _ sx min: dx. r _ (sx max: dx) + bbW.
					t _ sy min: dy. b _ (sy max: sy) + bbH.
					sourceBits _ self cCode:'fn(sourceHandle, &sourcePitch, l, t, r-l, b-t)'.
				].
				destBits _ sourceBits.
				destPitch _ sourcePitch.
				hasSurfaceLock _ true.
				^destBits ~~ 0
			].
			"Fall through - if not equal it'll be handled below"
		].
		destBits _ self cCode:'fn(destHandle, &destPitch, dx, dy, bbW, bbH)'.
		hasSurfaceLock _ true.
	].
	(sourceBits == 0 and:[noSource not]) ifTrue:["Blitting *from* OS surface"
		sourceHandle _ interpreterProxy fetchInteger: FormBitsIndex ofObject: sourceForm.
		lockSurfaceFn = 0 ifTrue:[self loadSurfacePlugin ifFalse:[^nil]].
		fn _ self cCoerce: lockSurfaceFn to: 'int (*)(int, int*, int, int, int, int)'.
		"Warping requiring the entire surface"
		isWarping ifTrue:[
			sourceBits _ self cCode:'fn(sourceHandle, &sourcePitch, 0, 0, sourceWidth, sourceHeight)'.
		] ifFalse:[
			sourceBits _ self cCode:'fn(sourceHandle, &sourcePitch, sx, sy, bbW, bbH)'.
		].
		hasSurfaceLock _ true.
	].
	^destBits ~~ 0 and:[sourceBits ~~ 0 or:[noSource]].