computeGeometry3x: aBlockX y: aBlockY z: aBlockZ uFrom: u1 to: u2 vFrom: v1 to: v2
divisionU: gridU divisionV: gridV

   "  compute the mesh for a surface that is defined by three functions of two parameters. "
 

	| vtx face dU dV vertices faces  mesh tex xTexOrigin yTexOrigin low high |
   
    dU := u2 - u1 / (gridU - 1).  " gridU, gridV is the number of points "
    dV := v2 - v1 / (gridV - 1).
	vtx _ WriteStream on: (B3DVector3Array new": gridU * gridV").
  	0 to: gridU - 1 do:[:idU | | u | 
                 u := dU * idU + u1.
		0 to: gridV - 1 do:[:idV| | v x y fn |
               v := dV * idV + v1.
               x := aBlockX value: u value: v.
               y := aBlockY value: u value: v.
               fn := aBlockZ value: u value: v.
			vtx nextPut: (B3DVector3 x: x asFloat  y: y asFloat  z: fn asFloat ).
 		].
	].

     " define the texture "
       yTexOrigin := 0.0.
     tex _ WriteStream on: (B3DTexture2Array new).
   	0 to: gridU - 1 do:[:x| xTexOrigin := 0.0.
        0 to: gridV - 1 do: [:idx| 
               tex nextPut:  xTexOrigin @ yTexOrigin.
               xTexOrigin := xTexOrigin + 0.5.
		].
      yTexOrigin := yTexOrigin + 0.5
   ].

	vertices _ vtx contents.
   
	faces _ WriteStream on: (B3DIndexedQuadArray new).
     low := 1.
	1 to: gridU -1 do:[:i|
         high := low + gridV.
		1 to: gridV - 1 do:[:j|
			face _ B3DIndexedQuad 
						with: low + j - 1
						with: low + j
						with: high + j
						with: high + j - 1.
			faces nextPut: face.
		].
        low := high.
 ].
   mesh := B3DIndexedQuadMesh new.
   mesh vertices: vertices;
          faces: faces contents;
          texCoords: tex contents.
  mesh vertexNormals: mesh computeVertexNormals.
  ^mesh