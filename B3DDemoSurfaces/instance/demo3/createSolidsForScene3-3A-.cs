createSolidsForScene3: aScene

	| sceneObj mat |

   
	sceneObj _ B3DSceneObject named: 'Surface1'.
	sceneObj geometry: (self createTriangleGeometryAndTexture: self surface1).
     sceneObj texture: (self colorTilesWith: (Color r: 0.7 g: 0.7 b: 0.7)
                                  and: (Color r: 0.8 g: 0.8 b: 0.7)). 

     mat := B3DMaterial new.
	mat shininess: 0.9;
          emission: (Color gray: 0.25);
          specularPart: (Color white). 
     sceneObj material: mat.

	aScene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Surface2'.
	sceneObj geometry: (self createTriangleGeometryAndTexture: self surface2).
     sceneObj texture: (self colorTilesWith: (Color r: 0.7 g: 0.7 b: 0.7)
                                  and: (Color r: 0.8 g: 0.8 b: 0.8)).  
     mat := B3DMaterial new.
	mat shininess: 0.7;
          emission: (Color gray: 0.25);
          specularPart: (Color gray: 0.99). 

     sceneObj material: mat.

	aScene objects add: sceneObj.