depth: d
	"Set the depth at which this Pattern of Colors will be rendered.  The results are cached in depth, width, height, and bits.  6/20/96 tk"

	d = depth ifTrue: [^ self].	"trust the cache"
	super depth: d.
	self cacheBits.	"Computer the rendering Bitmap"