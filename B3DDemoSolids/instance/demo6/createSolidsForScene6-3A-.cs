createSolidsForScene6: aScene

	| sceneObj solid colors c |

	sceneObj _ B3DSceneObject named: 'Surface1'.
     solid := B3DRegularSolid dodekahedron.
 
    c := OrderedCollection new: 5.
    c add: (Color r: 0.6 g: 0.0 b: 0.0);
            add: (Color r: 0.0 g: 0.6 b: 0.0);
            add: (Color r: 0.0 g: 0.0 b: 0.6);
            add: (Color r: 0.6 g: 0.6 b: 0.0);
            add: (Color r: 0.0 g: 0.6 b: 0.6).
     colors := OrderedCollection new: 12. 
     12 timesRepeat: [colors add: c].

     solid setVertexColors:  colors.
	sceneObj geometry: solid.
 
	aScene objects add: sceneObj.
