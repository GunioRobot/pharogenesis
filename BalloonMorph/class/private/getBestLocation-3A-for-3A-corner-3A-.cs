getBestLocation: vertices for: morph corner: cornerName
	"Try four rel locations of the balloon for greatest unclipped area.   12/99 sma"

	| rect maxArea verts rectCorner morphPoint mbc a mp dir bestVerts result usableArea |
	rect _ vertices first rect: (vertices at: 5).
	maxArea _ -1.
	verts _ vertices.
	usableArea _ (morph world ifNil: [self currentWorld]) viewBox.
	1 to: 4 do: [:i |
		dir _ #(vertical horizontal) atWrap: i.
		verts _ verts collect: [:p | p flipBy: dir centerAt: rect center].
		rectCorner _ #(bottomLeft bottomRight topRight topLeft) at: i.
		morphPoint _ #(topCenter topCenter bottomCenter bottomCenter) at: i.
		a _ ((rect
			align: (rect perform: rectCorner)
			with: (mbc _ morph boundsForBalloon perform: morphPoint))
				intersect: usableArea) area.
		(a > maxArea or: [a = rect area and: [rectCorner = cornerName]]) ifTrue:
			[maxArea _ a.
			bestVerts _ verts.
			mp _ mbc]].
	result _ bestVerts collect: [:p | p + (mp - bestVerts first)] "Inlined align:with:".
	^ result