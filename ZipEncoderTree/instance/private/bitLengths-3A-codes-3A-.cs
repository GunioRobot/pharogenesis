bitLengths: blArray codes: codeArray
	bitLengths _ blArray as: WordArray.
	codes _ codeArray as: WordArray.
	self assert:[(self bitLengthAt: maxCode) > 0].