qCompress: str
	"A very simple text compression routine designed for method temp names.
	Most common 12 chars get values 0-11 packed in one 4-bit nibble;
	others get values 12-15 (2 bits) * 16 plus next nibble.
	Last char of str must be a space so it may be dropped without
	consequence if output ends on odd nibble."
	| charTable odd ix oddNibble |
	charTable _  "Character encoding table must match qDecompress:"
	' eatrnoislcm bdfghjkpquvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789'.
	^ ByteArray streamContents:
		[:strm | odd _ true.  "Flag for odd or even nibble out"
		str do:
			[:char | ix _ (charTable indexOf: char) - 1.
			(ix <= 12 ifTrue: [ix]
				ifFalse: [Array with: ix//16+12 with: ix\\16])
				do:
				[:nibble | (odd _ odd not)
					ifTrue: [strm nextPut: oddNibble*16 + nibble]
					ifFalse: [oddNibble _ nibble]]].
		strm nextPut: strm position]
"
  | m s |  m _ CompiledMethod new.
s _ 'charTable odd ix oddNibble '.
^ Array with: s size with: (m qCompress: s) size
	with: (m qDecompress: (m qCompress: s))
"
