pixelScreenForDepth: depth
	"Return a 50% stipple containing alternating pixels of all-zeros and all-ones to be used as a mask at the given depth."

	| mask bits |
	mask _ (1 bitShift: depth) - 1.
	bits _ 2 * depth.
	[bits >= 32] whileFalse: [
		mask _ mask bitOr: (mask bitShift: bits).  "double the length of mask"
		bits _ bits + bits].
	^ Bitmap with: mask with: mask bitInvert32
