createSolidsForScene5: aScene

	| sceneObj solid |

	sceneObj _ B3DSceneObject named: 'Surface1'.
     solid := B3DRegularSolid dodekahedron.
 
    solid setFaceColors:
        (Array with: (Color yellow asB3DColor)
                    with: (Color yellow asB3DColor)
                    with: (Color orange asB3DColor)
                    with: (Color orange asB3DColor)
                    with: (Color cyan asB3DColor)
                    with: (Color cyan asB3DColor)),
(Array with: (Color lightGreen asB3DColor)
                    with: (Color lightGreen asB3DColor)
                    with: (Color blue asB3DColor)
                    with: (Color blue asB3DColor)
                    with: (Color brown asB3DColor)
                    with: (Color brown asB3DColor)) .
   "
     solid setVertexColors:  "
	sceneObj geometry: solid.
 
	aScene objects add: sceneObj.
