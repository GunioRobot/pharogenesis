hex8  "16r3333 hex8"
	| hex |
	hex _ self hex.  "16rNNN"
	hex size < 11
		ifTrue: [^ hex copyReplaceFrom: 4 to: 3
						 with: ('00000000' copyFrom: 1 to: 11-hex size)]
		ifFalse: [^ hex]