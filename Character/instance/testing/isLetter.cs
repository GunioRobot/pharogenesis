isLetter

	^ (EncodedCharSet charsetAt: self leadingChar) isLetter: self.
