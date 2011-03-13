hex
	| word nibble |
	^ String streamContents:
		[:strm |
		1 to: 5 do:
			[:i | word _ self at: i.
			1 to: 4 do: 
				[:s | nibble _ (word bitShift: -4+s*4) bitAnd: 16rF.
				strm nextPut: ('0123456789ABCDEF' at: nibble+1)]]]
"
(-2.0 to: 2.0) collect: [:f | f hex]
"