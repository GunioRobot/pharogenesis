createSolidsForScene1: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Surface1'.
	sceneObj geometry: self createBody.
     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.

	aScene objects add: sceneObj.
