createSolidsForScene8: aScene

	| sceneObj solid colors c |

	sceneObj _ B3DSceneObject named: 'Surface1'.
     solid := B3DRegularSolid icosahedron.

     colors := OrderedCollection new: 20.
     1 to: 20 do:
       [:hue | c := OrderedCollection new: 3.
           1 to: 3 do:
              [:s | 
                  c add: (Color h: hue*18 + (s * 3)  s: s + s  / 10.0 v: 0.9).
                " c add: (Color h: hue*18 + (s * 3)  s: s + s  / 10.0 v: 0.9) " 
                " c add: (Color h: hue*18 + (s * 3)  s: s + s  / 10.0 v: 0.9 - (s/10)) "
              ].
           colors add: c asArray.
      ].

     solid setVertexColors:  colors asArray.
	sceneObj geometry: solid.
 
	aScene objects add: sceneObj.
