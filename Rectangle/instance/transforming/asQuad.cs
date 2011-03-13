asQuad
	"Return an array of corner points in the order of a quadrilateral spec for WarpBlt.  Note that this is inset by 1 pixel from 'corners', as each point must be an actual pixel location."
	^ (self topLeft corner: self bottomRight-1) corners