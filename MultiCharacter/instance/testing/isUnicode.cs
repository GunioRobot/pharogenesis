isUnicode

	^ ((EncodedCharSet charsetAt: self leadingChar) isKindOf: LanguageEnvironment class).