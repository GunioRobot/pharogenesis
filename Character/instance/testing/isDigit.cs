isDigit

	^ (EncodedCharSet charsetAt: self leadingChar) isDigit: self.
