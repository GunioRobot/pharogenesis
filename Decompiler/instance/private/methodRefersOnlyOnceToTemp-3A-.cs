methodRefersOnlyOnceToTemp: offset
	| nRefs byteCode extension scanner |
	nRefs _ 0.
	offset <= 15
		ifTrue:
			[byteCode _ 16 + offset.
			(InstructionStream on: method) scanFor:
				[:instr | instr = byteCode ifTrue: [nRefs _ nRefs + 1].
				nRefs > 1]]
		ifFalse:
			[extension _ 64 + offset.
			scanner _ InstructionStream on: method.
			scanner scanFor:
				[:instr | (instr = 128 and: [scanner followingByte = extension])
							ifTrue: [nRefs _ nRefs + 1].
				nRefs > 1]].
	^ nRefs = 1
