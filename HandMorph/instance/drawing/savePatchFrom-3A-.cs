savePatchFrom: aCanvas
	"Save the part of the given canvas under this hand as a Form and return its bounding rectangle."
	"Details: The previously used patch Form is recycled when possible to reduce the burden on storage management."

	| damageRect myBnds |
	damageRect _ myBnds _ self fullBounds.
	savedPatch ifNotNil: [
		damageRect _ myBnds merge: (savedPatch offset extent: savedPatch extent)].
	(savedPatch == nil or: [savedPatch extent ~= myBnds extent])
		ifTrue: [  "allocate new patch form if needed"
			savedPatch _ Form extent: myBnds extent depth: aCanvas form depth].
	savedPatch
		copyBits: (myBnds translateBy: aCanvas origin)
		from: aCanvas form
		at: 0@0
		clippingBox: savedPatch boundingBox
		rule: Form over
		fillColor: nil.

	savedPatch offset: myBnds topLeft.
	^ damageRect
