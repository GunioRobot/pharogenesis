qCompress: string firstTry: firstTry
	"A very simple text compression routine designed for method temp names.
	Most common 12 chars get values 0-11 packed in one 4-bit nibble;
	others get values 12-15 (2 bits) * 16 plus next nibble.
	Last char of str must be a space so it may be dropped without
	consequence if output ends on odd nibble.
	Normal call is with firstTry == true."
	| charTable odd ix oddNibble names shorterStr maybe str temps |
	 str _ string isOctetString
				ifTrue: [string]
				ifFalse: [temps _ string findTokens: ' '.
					String
						streamContents: [:stream | 1
								to: temps size
								do: [:index | 
									stream nextPut: $t.
									stream nextPutAll: index asString.
									stream space]]].
	charTable _  "Character encoding table must match qDecompress:"
	' eatrnoislcm bdfghjkpquvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789'.
	^ ByteArray streamContents:
		[:strm | odd _ true.  "Flag for odd or even nibble out"
		oddNibble _ nil.
		str do:
			[:char | ix _ (charTable indexOf: char) - 1.
			(ix <= 12 ifTrue: [Array with: ix]
				ifFalse: [Array with: ix//16+12 with: ix\\16])
				do:
				[:nibble | (odd _ odd not)
					ifTrue: [strm nextPut: oddNibble*16 + nibble]
					ifFalse: [oddNibble _ nibble]]].
		strm position > 251 ifTrue:
			["Only values 1...251 are available for the flag byte
			that signals compressed temps. See the logic in endPC."
			"Before giving up completely, we attempt to encode most of
			the temps, but with the last few shortened to tNN-style names."
			firstTry ifFalse: [^ nil "already tried --give up now"].
			names _ str findTokens: ' '.
			names size < 8 ifTrue: [^ nil  "weird case -- give up now"].
			4 to: names size//2 by: 4 do:
				[:i | shorterStr _ String streamContents:
					[:s |
					1 to: names size - i do: [:j | s nextPutAll: (names at: j); space].
					1 to: i do: [:j | s nextPutAll: 't' , j printString; space]].
				(maybe _ self qCompress: shorterStr firstTry: false) ifNotNil: [^ maybe]].
			^ nil].
		strm nextPut: strm position]
"
  | m s |  m _ CompiledMethod new.
s _ 'charTable odd ix oddNibble '.
^ Array with: s size with: (m qCompress: s) size
	with: (m qDecompress: (m qCompress: s))
"
