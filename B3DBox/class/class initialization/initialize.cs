initialize
	"B3DBox initialize"
	| nrmls |
	nrmls := #(	(-1.0 0.0 0.0) (0.0 1.0 0.0) (1.0 0.0 0.0)
				(0.0 -1.0 0.0) (0.0 0.0 1.0) (0.0 0.0 -1.0)) 
			collect:[:spec| B3DVector3 x: spec first y: spec second z: spec third].
	BoxNormals := nrmls.
	"BoxNormals := Array new: 6.
	1 to: 6 do:[:i|
		BoxNormals at: i put: (FloatVector3 new).
		1 to: 3 do:[:j| (BoxNormals at: i) at: j put: ((nrmls at: i) at: j)]]."
	BoxFaceIndexes := #(	(1 2 3 4) (4 3 7 8) (8 7 6 5)
						(5 6 2 1) (6 7 3 2) (8 5 1 4)).
	BoxColors _ #(red green blue yellow gray cyan) collect:[:s| (Color perform: s) alpha: 0.5].