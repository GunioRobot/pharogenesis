eraseBits
	"Perform the erase operation, which puts 0's in the destination
	wherever the source (which is assumed to be just 1 bit deep)
	has a 1.  This requires the colorMap to be set in order to AND
	all 1's into the destFrom pixels regardless of their size."
	| oldMask oldMap |
	oldMask _ halftoneForm.
	halftoneForm _ nil.
	oldMap _ colorMap.
	self colorMap: (Bitmap with: 0 with: 16rFFFFFFFF).
	combinationRule _ Form erase.
	self copyBits. 		"Erase the dest wherever the source is 1"
	halftoneForm _ oldMask.	"already converted to a Bitmap"
	colorMap _ oldMap