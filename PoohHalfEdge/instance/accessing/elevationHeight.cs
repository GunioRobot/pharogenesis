elevationHeight
	| height center |
	height _ self length * 0.5.
	fanVertices ifNotNil:[
		center _ self center.
		fanVertices do:[:v| height _ height + (v dist: center)].
		height _ height / (fanVertices size + 1) asFloat].
	^height