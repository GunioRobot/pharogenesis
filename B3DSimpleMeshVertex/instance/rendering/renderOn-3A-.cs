renderOn: aRenderer
	color == nil ifFalse:[aRenderer color: color].
	texCoord == nil ifFalse:[aRenderer texCoord: texCoord].
	normal == nil ifFalse:[aRenderer normal: normal].
	aRenderer vertex: position.