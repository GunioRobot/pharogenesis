drawPoly: command
	|  verticesEnc fillColorEnc borderWidthEnc borderColorEnc vertices fillColor borderWidth borderColor |


	fillColorEnc := command at: 2.
	borderWidthEnc := command at: 3.
	borderColorEnc := command at: 4.

	verticesEnc := command copyFrom: 5 to: command size.

	fillColor := self class decodeColor: fillColorEnc.
	borderWidth := self class decodeInteger: borderWidthEnc.
	borderColor := self class decodeColor: borderColorEnc.
	vertices := verticesEnc collect: [ :enc | self class decodePoint: enc ].


	self drawCommand: [ :c |
		c drawPolygon: vertices color: fillColor borderWidth: borderWidth borderColor: borderColor ].
