codeSelectedTranslation
	| keys code |
	keys := selectedTranslations
				collect: [:key | self translations at: key].
	code := String
				streamContents: [:aStream | self translator fileOutOn: aStream keys: keys].
	(StringHolder new contents: code)
		openLabel: 'exported codes'