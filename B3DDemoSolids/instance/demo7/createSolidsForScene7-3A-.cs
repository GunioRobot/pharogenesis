createSolidsForScene7: aScene

	| sceneObj solid colors c |

	sceneObj _ B3DSceneObject named: 'Surface1'.
     solid := B3DRegularSolid dodekahedron.

     colors := OrderedCollection new: 12.
     1 to: 12 do:
       [:hue | c := OrderedCollection new: 5.
           1 to: 5 do:
              [:s | 
                  c add: (Color h: hue*30 + (s * 5)  s: s  / 10.0 v: 0.9).
                " c add: (Color h: hue*30 + (s * 5)  s: s + s  / 10.0 v: 0.9) " 
                " c add: (Color h: hue*30 + (s * 5)  s: s + s  / 10.0 v: 0.9 - (s/10)) "
              ].
           colors add: c.
      ].

     solid setVertexColors:  colors.
	sceneObj geometry: solid.
 
	aScene objects add: sceneObj.
