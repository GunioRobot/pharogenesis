borderStyle
	extension ifNil: [^BorderStyle default trackColorFrom: self].
	^(extension valueOfProperty: #borderStyle ifAbsent:[BorderStyle default]) trackColorFrom: self