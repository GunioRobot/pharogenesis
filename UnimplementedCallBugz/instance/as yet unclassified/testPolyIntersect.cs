testPolyIntersect

"self run: #testPolyIntersect"

self shouldnt: [ PolygonMorph initializedInstance 
					intersects: ( Rectangle center: Display center 
											extent: 100 asPoint ) ] 
	raise: Error .