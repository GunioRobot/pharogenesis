insertPoint: aPoint
	"Inserts a new point into a subdivision representing a Delaunay
	triangulation, and fixes the affected edges so that the result
	is still a Delaunay triangulation. This is based on the
	pseudocode from Guibas and Stolfi (1985) p.120, with slight
	modifications and a bug fix."
	| edge base |
	(area origin <= aPoint and:[aPoint <= area corner]) ifFalse:[self halt].
	edge := self locatePoint: aPoint.
	(edge origin = aPoint or:[edge destination = aPoint]) ifTrue:[^self].
	(edge isPointOn: aPoint) ifTrue:[
		edge := edge originPrev.
		edge originNext deleteEdge].
	"Connect the new point to the vertices of the containing
	triangle (or quadrilateral, if the new point fell on an
	existing edge.)"
	base := self quadEdgeClass new.
	(base first) origin: edge origin; destination: aPoint.
	base first spliceEdge: edge.
	startingEdge := base.
	[base := edge connectEdge: base first symmetric.
	edge := base first originPrev.
	edge leftNext == startingEdge first] whileFalse.
	"Examine suspect edges to ensure that the Delaunay condition is satisfied."
	[true] whileTrue:[ | t |
	t := edge originPrev.
	((edge isRightPoint: t destination) and:[
		self insideCircle: aPoint with: edge origin with: t destination with: edge destination])
			 ifTrue:[
					edge swapEdge.
					edge := edge originPrev.
	] ifFalse:[
		(edge originNext == startingEdge first) ifTrue:[^self]. "No more suspect edges"
		"pop a suspect edge"
		edge := edge originNext leftPrev]].