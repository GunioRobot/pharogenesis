tallyPixelValues
	"Return a Bitmap with tallies in it of the number of pixels in this Form that have each pixel value. Note that several Forms may be tallied into the same table by tallyPixelValuesPrimitive:into: with the same table. Also Forms of depth 16 or 32 can be tallied into a tables of size 512, 4096, or 32768 entries by making a direct call with a Bitmap of the given size."
	| tallies pixPerWord extraZeros |
	tallies _ Bitmap new: (1 bitShift: (self depth min: 15)).
	self tallyPixelValuesPrimitive: self boundingBox into: tallies.
	pixPerWord _ 32 // depth.
	(self width \\ pixPerWord) = 0
		ifFalse: [
			"subtract extra zeros counts due to word-boundary"
			extraZeros _ self height * (pixPerWord - (self width \\ pixPerWord)).
			tallies at: 1 put: (tallies at: 1) - extraZeros].
	^ tallies
