computeGeometry6x: aBlockX y: aBlockY z: aBlockZ uFrom: u1 to: u2 vFrom: v1 to: v2
divisionU: gridU divisionV: gridV

   "  compute the mesh for a surface that is defined by three functions of two parameters. "
 

	| vtx face dU dV vertices faces mesh low high vtxColors idxF |
   
    dU := u2 - u1 / (gridU - 1).  " gridU, gridV is the number of points "
    dV := v2 - v1 / (gridV - 1).
	vtx _ WriteStream on: (B3DVector3Array new).
     vtxColors := WriteStream on: B3DColor4Array new.
  	0 to: gridU - 1 do:
        [:idU | | u | 
          u := dU * idU + u1.
          0 to: gridV - 1 do:[:idV | | v x y fn |
               v := dV * idV + v1.
               x := aBlockX value: u value: v.
               y := aBlockY value: u value: v.
               fn := aBlockZ value: u value: v.
			vtx nextPut: (B3DVector3 x: x asFloat  y: y asFloat  z: fn asFloat).
               vtxColors nextPut: (Color h: 360*(v - v1)/(v2 -  v1)
                                            s: 0.6*((u - u1) abs min: (u - u2) abs)/(u2 -  u1) + 0.4
                                            v: -0.6*((u - u1) abs min: (u - u2) abs)/(u2 -  u1) + 1.0) asB3DColor
 		].
	].


	vertices _ vtx contents.
   
	faces _ B3DIndexedTriangleArray new: (gridU - 1)*(gridV - 1)*2.
     idxF := 0.
     low := 1.
	1 to: gridU -1 do:[:i |
         high := low + gridV.
		1 to: gridV - 1 do:[:j |
			face _ B3DIndexedTriangle 
						with: low + j - 1
						with: low + j
						with: high + j
						"with: high + j - 1".
			faces at: (idxF := idxF + 1) put: face.

              face := B3DIndexedTriangle 
                        with: low + j - 1
                        "with: low + j"
                        with: high + j
                        with: high + j - 1.
			faces at: (idxF := idxF + 1) put: face.

		].
        low := high.
 ].
   mesh := B3DIndexedTriangleMesh new.
   mesh vertices: vertices;
          faces: faces;
          vertexColors: vtxColors contents.
  ^mesh