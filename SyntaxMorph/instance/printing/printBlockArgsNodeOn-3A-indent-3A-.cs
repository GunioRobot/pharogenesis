printBlockArgsNodeOn: strm indent: level

	| argString |

	self
		submorphsDoIfSyntax: [ :sub |
			(argString := sub decompile) isEmpty ifFalse: [
				strm 
					nextPut: $:;
					nextPutAll: argString;
					space
			].
		] 
		ifString: [ :sub |
			"self printSimpleStringMorph: sub on: strm	<<<< do we need this??"
		].
	strm nextPut: $|; crtab: level.

