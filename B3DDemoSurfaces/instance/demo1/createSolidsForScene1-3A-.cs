createSolidsForScene1: aScene

	| sceneObj |

	sceneObj _ B3DSceneObject named: 'Surface1'.
	sceneObj geometry: (self createQuadGeometryAndTexture: self surface1).
     sceneObj texture: (self colorTilesWith: (Color r: 0.6 g: 0.1 b: 0.0)
                                  and: (Color r: 0.95 g: 0.1 b: 0.0)). 

	aScene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Surface2'.
	sceneObj geometry: (self createQuadGeometryAndTexture: self surface2).
     sceneObj texture: (self colorTilesWith: (Color r: 0.0 g: 0.65 b: 0.0)
                                  and: (Color r: 0.0 g: 0.95 b: 0.0)).

	aScene objects add: sceneObj.