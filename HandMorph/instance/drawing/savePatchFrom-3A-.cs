savePatchFrom: aCanvas
	"Save the part of the given canvas under this hand as a Form and return its bounding rectangle."
	"Details: The previously used patch Form is recycled when possible to reduce the burden on storage management."

	| damageRect myBnds |
	damageRect _ myBnds _ self fullBounds.
	savedPatch ifNotNil: [
		damageRect _ myBnds merge: (savedPatch offset extent: savedPatch extent)].
	(savedPatch == nil or: [savedPatch extent ~= myBnds extent])
		ifTrue: [  "allocate new patch form if needed"
			savedPatch _ aCanvas form allocateForm: myBnds extent].
	aCanvas
		contentsOfArea: (myBnds translateBy: aCanvas origin)
		into: savedPatch.
	savedPatch offset: myBnds topLeft.
	^ damageRect
