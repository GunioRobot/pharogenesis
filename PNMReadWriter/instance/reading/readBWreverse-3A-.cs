readBWreverse: flagXor
	"B&W for PAM"
	| val form bytesRow nBytes |
	stream binary.
	form _ Form extent: cols@rows depth: 1.
	nBytes _ (cols/8) ceiling.
	bytesRow _ (cols/32) ceiling * 4.
	0 to: rows-1 do: [:y | | i |
		i _ 1 + (bytesRow*y).
		0 to: nBytes-1 do: [:x |
			val _ stream next.
			flagXor ifTrue:[val _ val bitXor: 16rFF].
			form bits byteAt: i put: val.
			i _ i+1.
		]
	].
	^form
