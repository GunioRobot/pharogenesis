privateNeedsClipVB: visibleFlag
	"Determine if a vertex buffer with the given visibility flag must be clipped.
	Return false if either visibleFlag == true (meaning the vertex buffer is completely inside the view frustum) or the rasterizer can clip by itself (it usually can)."
	^visibleFlag ~~ true and:[rasterizer needsClip]