createTriangleGeometry: fn withDerivatives: dufn and: dvfn
 uFrom: xStart to: xStop vFrom: yStart to: yStop
        divisionU: nroPx divisionV: nroPy
        coloring: aBlock
  " here we create a triangle mesh. The scene is created elsewhere. "

   |  stepPx stepPy x y
     low high idxF
     vtx face faces mesh vtxNormals vtxColors fnValue |

  stepPx := xStop - xStart / (nroPx - 1).
  stepPy := yStop - yStart / (nroPy - 1).
  
  vtx _ WriteStream on: (B3DVector3Array new: nroPx * nroPy).
  dufn notNil
    ifTrue: [vtxNormals _ WriteStream on: (B3DVector3Array new: nroPx * nroPy)].
  aBlock notNil ifTrue:
    [vtxColors := WriteStream on: (B3DColor4Array new: nroPx * nroPy)].
  x := xStart.
  y := yStart.
    " compute the vertices "
  nroPx timesRepeat:
    [y := yStart.
     nroPy timesRepeat:
       [vtx nextPut: (B3DVector3 x: x y: (fnValue := fn value: x value: y) z: y).
        dufn notNil
           ifTrue: [vtxNormals nextPut:
                    (B3DVector3 x: (dufn value: x value: y)
                                  y: -1.0
                                  z: (dvfn value: x value: y)) safelyNormalized].
        aBlock notNil
           ifTrue: [vtxColors nextPut: (aBlock value: x - xStart/(xStop - xStart)
                                                    value: y - yStart/(yStop - yStart)
                                                    value: fnValue)].
        y := y + stepPy.  
       ].
      x := x + stepPx. 
    ].

     faces := B3DIndexedTriangleArray new: (nroPx - 1)*(nroPy - 1)*2.  

   idxF := low := 1.
   1 to: nroPx -1 do: [:i |
      high := low + nroPy.
      1 to: nroPy - 1 do: [:j |
         face := B3DIndexedTriangle 
                   with: low + j - 1
                   with: low + j
                   with: high + j.
         faces at: idxF put: face.
         idxF := idxF + 1.
         face := B3DIndexedTriangle 
                   with: low + j - 1
                   with: high + j
                   with: high + j - 1.
         faces at: idxF put: face.
         idxF := idxF + 1.
        ].
      low := high.
     ].



   mesh := B3DIndexedTriangleMesh new.
   mesh vertices: vtx contents;
          faces: faces.
   dufn notNil
     ifTrue: [mesh vertexNormals: vtxNormals contents].
   aBlock notNil
     ifTrue: [mesh vertexColors: vtxColors contents].
 
  ^mesh
  