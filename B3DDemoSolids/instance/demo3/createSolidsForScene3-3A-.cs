createSolidsForScene3: aScene

	| sceneObj |

	sceneObj _ B3DSceneObject named: 'Surface1'.
	sceneObj geometry: (self createBodyWithFaceColors: 
           (Array with: (Color yellow asB3DColor)
                    with: (Color lightGreen asB3DColor)
                    with: (Color blue asB3DColor)
                    with: (Color orange asB3DColor)
                    with: (Color cyan asB3DColor)
                    with: (Color brown asB3DColor))).

	aScene objects add: sceneObj.
