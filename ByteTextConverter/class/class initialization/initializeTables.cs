initializeTables
	"Initialize the mappings to and from unicode."

	| byteToUnicodeSpec leadingChar |
	byteToUnicodeSpec := self byteToUnicodeSpec.

	leadingChar := self languageEnvironment leadingChar.
	byteToUnicode := byteToUnicodeSpec collect: [:charValue |
		Character leadingChar: leadingChar code: charValue].

	unicodeToByte := Dictionary new.
	"Mind the offset because first 128 characters are not stored into byteToUnicodeSpec"
	byteToUnicodeSpec keysAndValuesDo: [:byteEntry :unicodeEntry |
		unicodeToByte at: unicodeEntry put: (127 + byteEntry) asCharacter]