areasRemainingToFill: aRectangle 
	"Figuring out which parts of a Sketch are not translucent can be tricky to
	do... (Colors used can be transparent (see canBeEnlargedWithB3D)
	- Source Form can be depth 32 with alpha bits, etc.
	It's not certain whether the calculation to find areas remaining outside
	opaque parts will be of significant value (i.e. they probably will be merged
	when creating damage rects for Morphs beneath anyways), therefore handle
	it like we always have to redraw content beneath... At least for now"
	^ Array with: aRectangle