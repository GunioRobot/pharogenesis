upTo: delim 
	| resultStream nextChar |
	resultStream _ WriteStream on: (self streamBuffer: 100).

	[(nextChar _ self next) = delim]
		whileFalse: [
			nextChar
				ifNil: [^resultStream contents]
				ifNotNil: [resultStream nextPut: nextChar]].

	^resultStream contents