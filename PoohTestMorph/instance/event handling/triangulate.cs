triangulate
	subdivision _ PoohSubdivision points: points shuffled.
	subdivision constraintOutline: points.
	subdivision markExteriorEdges.
	firstPoly _ subdivision triangulate.
