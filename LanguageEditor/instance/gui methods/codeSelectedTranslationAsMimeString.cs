codeSelectedTranslationAsMimeString
	| keys code tmpStream s2 gzs cont |
	keys := selectedTranslations
				collect: [:key | self translations at: key].
	code := String
				streamContents: [:aStream | self translator fileOutOn: aStream keys: keys].

	tmpStream _ MultiByteBinaryOrTextStream on: ''.
	tmpStream converter: UTF8TextConverter new.
	tmpStream nextPutAll: code.
	s2 _ RWBinaryOrTextStream on: ''.
	gzs := GZipWriteStream on: s2.
	tmpStream reset.
	gzs nextPutAll: (tmpStream binary contentsOfEntireFile asString) contents.
	gzs close.
	s2 reset.

	cont _ String streamContents: [:strm |
		strm nextPutAll: 'NaturalLanguageTranslator loadForLocaleIsoString: '.
		strm nextPut: $'.
		strm nextPutAll: translator localeID isoString.
		strm nextPut: $'.
		strm nextPutAll: ' fromGzippedMimeLiteral: '.
		strm nextPut: $'.
		strm nextPutAll: (Base64MimeConverter mimeEncode: s2) contents.
		strm nextPutAll: '''.!'.
		strm cr.
	].
	
	(StringHolder new contents: cont)
		openLabel: 'exported codes in Gzip+Base64 encoding'