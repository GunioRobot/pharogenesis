drawSubdivisionTrianglesOn: cc
	| colors |
true ifTrue:[^self].
	subdivision ifNil:[^self].
	colors _ #(red green blue yellow magenta cyan) collect:[:s| Color perform: s].
	subdivision innerTriangles doWithIndex:[:f :idx|
		cc drawPolygon: f 
			color: (colors atWrap: idx) 
			borderWidth: 0 borderColor: Color transparent].
