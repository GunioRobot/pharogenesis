createSolidsForScene4: aScene

	| sceneObj |

	sceneObj _ B3DSceneObject named: 'Surface1'.
	sceneObj geometry: (self createBodyWithFaceColors: 
           (Array with: (Color yellow asB3DColor)
                    with: (Color lightGreen asB3DColor)
                    with: (Color blue asB3DColor)
                    with: (Color orange asB3DColor)
                    with: (Color cyan asB3DColor)
                    with: (Color brown asB3DColor))).
     sceneObj geometry: (sceneObj geometry transformedBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 0.5 z: 0.5))). 
     sceneObj geometry translateBy: (B3DVector3 x: 1.0  y: 0.5  z: 1.0).
	aScene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Surface2'.
	sceneObj geometry: (self createBodyWithFaceColors: 
           (Array with: (Color yellow asB3DColor)
                    with: (Color lightGreen asB3DColor)
                    with: (Color blue asB3DColor)
                    with: (Color orange asB3DColor)
                    with: (Color cyan asB3DColor)
                    with: (Color brown asB3DColor))).
     sceneObj geometry: (sceneObj geometry transformedBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 0.5 z: 0.5))).     
	aScene objects add: sceneObj.
