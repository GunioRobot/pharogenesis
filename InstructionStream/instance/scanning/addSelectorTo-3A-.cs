addSelectorTo: set 
	"If this instruction is a send, add its selector to set."

	| byte literalNumber byte2 |
	byte _ self method at: pc.
	byte < 128 ifTrue: [^self].
	byte >= 176
		ifTrue: 
			["special byte or short send"
			byte >= 208
				ifTrue: [set add: (self method literalAt: (byte bitAnd: 15) + 1)]
				ifFalse: [set add: (Smalltalk specialSelectorAt: byte - 176 + 1)]]
		ifFalse: 
			[(byte between: 131 and: 134)
				ifTrue: 
					[byte2 _ self method at: pc + 1.
					byte = 131 ifTrue: [set add: (self method literalAt: byte2 \\ 32 + 1)].
					byte = 132 ifTrue: [byte2 < 64 ifTrue: [set add: (self method literalAt: (self method at: pc + 2) + 1)]].
					byte = 133 ifTrue: [set add: (self method literalAt: byte2 \\ 32 + 1)].
					byte = 134 ifTrue: [set add: (self method literalAt: byte2 \\ 64 + 1)]]]