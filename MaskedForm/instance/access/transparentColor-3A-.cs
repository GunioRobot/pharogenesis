transparentColor: aColor
	"Change the transparent color.  Alters the mask as needed.  Checks to see if more than one code used in theForm has this color.  If so, asks the user to click on the color that should be transparent.
     1. recompute original form
	2. change transp color
	3. compute new theForm and mask
6/21/96 tk"

	self restoreOverlap.	"recompute the original colors in theForm"
	self setForm: theForm transparentColor: aColor


