viewport: aRectangle
	"check if we need a transform override for the viewport"
	| vp clipRect |
	vp _ aRectangle.
	clipRect _ rasterizer clipRect.
	(clipRect containsRect: vp) ifTrue:[
		"Good. The viewport is fully within the clip rect."
		vpTransform _ nil.
	] ifFalse:[
		"We need a transform override here"
		vp _ clipRect intersect: vp.
		"Actual viewport is vp. Now scale from aRectangle into vp.
		This is equivalent to picking vp center with vp extent."
		vp area > 0 ifTrue:[
			vpTransform _ self pickingMatrixFor: aRectangle at: (vp origin + vp corner) * 0.5 extent: vp extent].
	].
	"And set actual viewport"
	super viewport: vp.