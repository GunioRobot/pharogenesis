drawSubdivisionSpineOn: cc

	| p1 p2 p3 center colors |
	firstPoly ifNil:[^self].
false ifTrue:[
	colors _ #(red green blue yellow magenta cyan) collect:[:s| Color perform: s].
] ifFalse:[
	colors _ {Color green}.
].
	firstPoly validFacesDo:[:poly|
true ifTrue:[
		p1 _ p2 _ p3 _ nil.
true ifTrue:[
		poly e1 fanVertices
			ifNil:[cc line: poly e1 origin to: poly e1 destination width: 1 color: poly e1 classificationColor].
		poly e2 fanVertices
			ifNil:[cc line: poly e2 origin to: poly e2 destination width: 1 color: poly e2 classificationColor].
		poly e3 fanVertices
			ifNil:[cc line: poly e3 origin to: poly e3 destination width: 1 color: poly e3 classificationColor].
].
		poly e1 leftFace ifNotNil:[p1 _ poly e1 center].
		poly e2 leftFace ifNotNil:[p2 _ poly e2 center].
		poly e3 leftFace ifNotNil:[p3 _ poly e3 center].
		(p1 notNil and:[p2 notNil and:[p3 notNil]]) ifTrue:[
			center _ poly center.
			poly e1 fanVertices 
				ifNil:[cc line: center to: p1 width: 1 color: Color red].
			poly e2 fanVertices
				ifNil:[cc line: center to: p2 width: 1 color: Color red].
			poly e3 fanVertices
				ifNil:[cc line: center to: p3 width: 1 color: Color red].
		] ifFalse:[
			(p1 notNil and:[p2 notNil])
				ifTrue:[cc line: p1 to: p2 width: 1 color: Color red].
			(p2 notNil and:[p3 notNil])
				ifTrue:[cc line: p2 to: p3 width: 1 color: Color red].
			(p3 notNil and:[p1 notNil])
				ifTrue:[cc line: p3 to: p1 width: 1 color: Color red].
		].
].
true ifTrue:[
		poly e1 fanVertices ifNotNil:[
			center _ poly isJunction ifTrue:[poly center] ifFalse:[poly e1 center].
			poly e1 fanVertices doWithIndex:[:pt :idx|
				cc line: center to: pt width: 1 color: (colors atWrap: idx)]].
		poly e2 fanVertices ifNotNil:[
			center _ poly isJunction ifTrue:[poly center] ifFalse:[poly e2 center].
			poly e2 fanVertices doWithIndex:[:pt :idx|
				cc line: center to: pt width: 1 color: (colors atWrap: idx)]].
		poly e3 fanVertices ifNotNil:[
			center _ poly isJunction ifTrue:[poly center] ifFalse:[poly e3 center].
			poly e3 fanVertices doWithIndex:[:pt :idx|
				cc line: center to: pt width: 1 color: (colors atWrap: idx)]].
].
	].