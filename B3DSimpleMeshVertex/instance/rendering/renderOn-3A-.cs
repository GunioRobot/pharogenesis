renderOn: aRenderer
	color == nil ifFalse:[aRenderer color: color].
	texCoord == nil ifFalse:[aRenderer texCoords: texCoord].
	normal == nil ifFalse:[aRenderer normal: normal].
	aRenderer vertex: position.