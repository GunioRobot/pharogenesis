createSolidsForScene7: aScene

     | sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sample Cube'.
	sceneObj geometry:
          (self createTriangleGeometry: [:x :y | (x*x + (y*y)) negated exp * x * 4.0]
                        withDerivatives: [:u1 :v1 | (u1*u1 + (v1*v1)) negated exp *  4.0 - ((u1*u1 + (v1*v1)) negated exp * u1 *u1* 8.0)]
                        and: [:u1 :v1 | ((u1*u1 + (v1*v1)) negated exp * u1 *v1* -8.0)]
                        uFrom: -2.0 to:2.0
                        vFrom: -2.0 to: 2.5
                        divisionU: 38
                        divisionV: 42
                        coloring: nil 
          ).

     mat := B3DMaterial new.
	mat shininess: 0.9;
          emission: (Color gray: 0.22);
          specularPart: (Color gray: 0.8). 

	sceneObj material: mat.

	aScene objects add: sceneObj.