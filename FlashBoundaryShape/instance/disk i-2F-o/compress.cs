compress
	(points isOctetString) ifFalse:[
		points _ FlashCodec compress: self.
		leftFills _ rightFills _ lineWidths _ lineFills _ fillStyles _ nil].