setupVertexOrder: face
	| p1 p2 i1 i2 i3 p3  |
	i1 _ face p1Index.
	i2 _ face p2Index.
	i3 _ face p3Index.
	p1 _ vertices at: i1.
	p2 _ vertices at: i2.
	p3 _ vertices at: i3.
	(p1 sortsBefore: p2) ifTrue:[
		(p2 sortsBefore: p3) ifTrue:[
			face p1Index: i1; p2Index: i2; p3Index: i3.
		] ifFalse:[
			(p1 sortsBefore: p3)
				ifTrue:[face p1Index: i1; p2Index: i3; p3Index: i2]
				ifFalse:[face p1Index: i3; p2Index: i1; p3Index: i2]
		].
	] ifFalse:[
		(p1 sortsBefore: p3) ifTrue:[
			face p1Index: i2; p2Index: i1; p3Index: i3.
		] ifFalse:[
			(p2 sortsBefore: p3)
				ifTrue:[face p1Index: i2; p2Index: i3; p3Index: i1]
				ifFalse:[face p1Index: i3; p2Index: i2; p3Index: i1]
		]
	].
	B3DScanner doDebug ifTrue:[
		p1 _ vertices at: face p1Index.
		p2 _ vertices at: face p2Index.
		p3 _ vertices at: face p3Index.
		((p1 sortsBefore: p2) and:[(p2 sortsBefore: p3) and:[p1 sortsBefore: p3]])
			ifFalse:[self error:'Vertex order problem'].
	].
