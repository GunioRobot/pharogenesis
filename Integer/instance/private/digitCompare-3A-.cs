digitCompare: arg
	"Compare the magnitude of self with that of arg.
	Return a code of 1, 0, -1 for self >, = , < arg"
	| len arglen argDigit selfDigit |
	len _ self digitLength.
	(arglen _ arg digitLength) ~= len 
		ifTrue: [arglen > len
					ifTrue: [^-1]
					ifFalse: [^1]].
	[len > 0]
		whileTrue: 
			[(argDigit _ arg digitAt: len) ~= (selfDigit _ self digitAt: len) 
				ifTrue: [argDigit < selfDigit
							ifTrue: [^1]
							ifFalse: [^-1]].
			len _ len - 1].
	^0