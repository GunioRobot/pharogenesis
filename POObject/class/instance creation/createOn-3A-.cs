createOn: aSimplePolygon
	| tdo  |
	tdo _ self new.
	tdo polygon: aSimplePolygon.
	tdo triangulation: (POTriangulation on: aSimplePolygon vertices).
	tdo tailor; classify; prune.
	^ tdo