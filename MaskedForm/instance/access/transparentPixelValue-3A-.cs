transparentPixelValue: pixVal
	"Specify the transparent color by its internal raw bit pattern.  Changes the transparent color.  Alters the mask as needed.
     1. recompute original form
	2. change transp color
	3. compute new theForm and mask
6/21/96 tk"

	self restoreOverlap.	"recompute the original colors in theForm"
	self setForm: theForm transparentPixelValue: pixVal
	


