createSolidsForScene4: aScene

     | sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Surface1'.
	sceneObj geometry: (self createQuadGeometry: [:x :y |  2 + (2*x) sin * (1 + (y * 2) cos) *2 / 3]).

     mat := B3DMaterial new.
	mat emission: (Color r: 0.7 g: 0.6 b: 0.3);
          shininess: 0.9";
         diffusePart: ( Color r: 0.6 g: 0.3 b: 0.2).
	mat ambientPart: (Color r:0.5 g: 0.7 b: 0.3)".
     mat specularPart: Color white. 
	sceneObj material: mat.

	scene objects add: sceneObj.

