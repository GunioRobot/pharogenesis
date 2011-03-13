drawPolygon: vertices color: aColor borderWidth: bw borderColor: bc
	self outlinePolygon:vertices;
	     setLinewidth:bw;
	     fill:aColor andStroke: ((bc isKindOf: Symbol) ifTrue: [Color gray] ifFalse: [bc]).

