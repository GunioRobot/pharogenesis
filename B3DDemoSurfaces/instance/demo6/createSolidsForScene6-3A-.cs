createSolidsForScene6: aScene

     | sceneObj |

	sceneObj _ B3DSceneObject named: 'Sample Cube'.
	sceneObj geometry:
          (self computeGeometry6x: [:u1 :v1 | v1 cos*2 + (0.5*(u1 cos*(v1 cos) negated + (u1 sin*v1 sin/2.0/2.236068)))]
                        y: [:u3 :v3 | u3 sin / 2.236068 + (v3/2.0)]
                        z: [:u2 :v2 | v2 sin * 2.0 + (0.5*(v2 sin*(u2 cos) negated - ((u2 sin*v2 cos / 2/2.236068))))]
                        uFrom: Float pi negated  to: Float pi
                        vFrom: -3.0 * Float pi to: 3.0 *Float pi
                        divisionU: 15
                        divisionV: 200
          ).
	aScene objects add: sceneObj.
