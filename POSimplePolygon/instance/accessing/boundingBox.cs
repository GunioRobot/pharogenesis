boundingBox
	^ vertices inject: (vertices first extent: 0@0) into: [:rec :pts| 
		rec encompass: pts].
