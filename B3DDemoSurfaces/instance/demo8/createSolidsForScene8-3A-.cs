createSolidsForScene8: aScene

     | sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sample Cube'.
	sceneObj geometry:
          (self createTriangleGeometry: [:x :y | (x*x + (y*y)) negated exp * x * 4.0]
                        withDerivatives: nil
                        and: nil
                        uFrom: -2.0 to:2.0
                        vFrom: -2.0 to: 2.5
                        divisionU: 38
                        divisionV: 42
                        coloring: [:x :y :f | (Color h: 360*x
                                            s: 0.5*y + 0.5
                                            v: -0.6*y + 1.0) asB3DColor ] 
          ).

     mat := B3DMaterial new.
	mat shininess: 0.9;
          emission: (Color gray: 0.22). 

	sceneObj material: mat.

	aScene objects add: sceneObj.