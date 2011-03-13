cacheBits
	"Actual bits must be recomputed and cached for the display depth.  Width, that is (extent x), is limited to 32/depth.  If shown at a depth that is too wide, right hand side colors will not show.
	If you reach in and change a color in colorArray2D, then call this to update the pattern.  6/20/96 tk"

| word row |
depth == nil ifTrue: [self error: 'for what depth?'].
width _ 32//depth.
height _ colorArray2D height.
bits _ Bitmap new: height.	"always 32 bits across"

1 to: height do: [:j |
	word _ 0.
	row _ colorArray2D atRow: j.
	1 to: 32//depth do: [:pix | 
		word _ (word bitShift: depth) bitOr: 
			((row atWrap: pix) pixelValueForDepth: depth)].
	bits at: j put: word].