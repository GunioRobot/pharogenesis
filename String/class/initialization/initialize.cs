initialize  "String initialize"
	AsciiOrder _ (0 to: 255) as: ByteArray.
	CaseInsensitiveOrder _ AsciiOrder copy.
	($a to: $z) do:
		[:c | CaseInsensitiveOrder at: c asciiValue
				put: (CaseInsensitiveOrder at: c asUppercase asciiValue)]