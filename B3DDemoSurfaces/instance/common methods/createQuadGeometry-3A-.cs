createQuadGeometry: fn 

  " here we create a QuadMesh. The scene is created elsewhere. "

   | nroPx nroPy stepPx stepPy x y
     low high xStart xStop yStart yStop idxF
     vtx face faces  mesh |

  nroPx := 48.  " number of points in direction x "
  nroPy := 48.  " number of points in direction y "
  xStart := 0.0.
  xStop  := 6.25.
  yStart := 0.0.
  yStop  := 6.25.
  stepPx := xStop - xStart / (nroPx - 1).
  stepPy := yStop - yStart / (nroPy - 1).
  
  vtx _ WriteStream on: (B3DVector3Array new: nroPx * nroPy).
  x := xStart.
  y := yStart.
    " compute the vertices "
  nroPx timesRepeat:
    [y := yStart.
     nroPy timesRepeat:
       [vtx nextPut: (B3DVector3 x: x y: (fn value: x value: y) z: y).
        y := y + stepPy.  
       ].
      x := x + stepPx. 
    ].

   "  create the quads "
   faces _ B3DIndexedQuadArray new: (nroPx - 1)*(nroPy - 1).
   idxF := low := 1.
	1 to: nroPx -1 do: [:i |
         high := low + nroPy.
		1 to: nroPy - 1 do: [:j |
			face _ B3DIndexedQuad 
						with: low + j - 1
						with: low + j
						with: high + j
						with: high + j - 1.
			faces at: idxF put: face.
              idxF := idxF + 1.
		].
        low := high.
      ].


   mesh := B3DIndexedQuadMesh new.
   mesh vertices: vtx contents;
          faces: faces.
  mesh vertexNormals: mesh computeVertexNormals.
  ^mesh
  