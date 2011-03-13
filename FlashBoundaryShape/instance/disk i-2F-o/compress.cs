compress
	(points isOctetString) ifFalse:[
		points := FlashCodec compress: self.
		leftFills := rightFills := lineWidths := lineFills := fillStyles := nil].