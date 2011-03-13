readOneCharacter
	| str a encoding bbx form bits hi low pos |
	((str _ self getLine) beginsWith: 'ENDFONT') ifTrue: [^ {nil. nil. nil}].
	(str beginsWith: 'STARTCHAR') ifFalse: [self errorFileFormat].
	((str _ self getLine) beginsWith: 'ENCODING') ifFalse: [self errorFileFormat].
	encoding _ Integer readFromString: str substrings second.
	(self getLine beginsWith: 'SWIDTH') ifFalse: [self errorFileFormat].
	(self getLine beginsWith: 'DWIDTH') ifFalse: [self errorFileFormat].
	
	((str _ self getLine) beginsWith: 'BBX') ifFalse: [self errorFileFormat].
	a _ str substrings.
	bbx _ (2 to: 5) collect: [:i | Integer readFromString: (a at: i)].
	((str _ self getLine) beginsWith: 'ATTRIBUTES') ifTrue: [str _ self getLine].
	(str beginsWith: 'BITMAP') ifFalse: [self errorFileFormat].

	form _ Form extent: (bbx at: 1)@(bbx at: 2).
	bits _ form bits.
	pos _ 0.
	1 to: (bbx at: 2) do: [:t |
		1 to: (((bbx at: 1) - 1) // 8 + 1) do: [:i |
			hi _ (('0123456789ABCDEF' indexOf: (file next asUppercase)) - 1) bitShift: 4.
			low _ ('0123456789ABCDEF' indexOf: (file next asUppercase)) - 1.
			
			bits byteAt: (pos+i) put: (hi+low).
		].
		file next ~= Character cr ifTrue: [self errorFileFormat].
		pos _ pos + ((((bbx at: 1) // 32) + 1) * 4).
	].

	(self getLine beginsWith: 'ENDCHAR') ifFalse: [self errorFileFormat].

	encoding < 0 ifTrue: [^{nil. nil. nil}].
	^{form. encoding. bbx}.
	
	
	