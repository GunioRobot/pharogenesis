transformIfNotNilIfNil: encoder
	((self checkBlock: (arguments at: 1) as: 'NotNil arg' from: encoder)
		and: [self checkBlock: (arguments at: 2) as: 'Nil arg' from: encoder])
		ifTrue: 
			[selector _ SelectorNode new key: #ifTrue:ifFalse: code: #macro.
			receiver _ MessageNode new
				receiver: receiver
				selector: #==
				arguments: (Array with: NodeNil)
				precedence: 2
				from: encoder.
			arguments swap: 1 with: 2.
			^true]
		ifFalse: 
			[^false]