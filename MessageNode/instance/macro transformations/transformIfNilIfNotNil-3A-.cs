transformIfNilIfNotNil: encoder
	((self checkBlock: (arguments at: 1) as: 'Nil arg' from: encoder)
		and: [self checkBlock: (arguments at: 2) as: 'NotNil arg' from: encoder])
		ifTrue: 
			[selector _ SelectorNode new key: #ifTrue:ifFalse: code: #macro.
			receiver _ MessageNode new
				receiver: receiver
				selector: #==
				arguments: (Array with: NodeNil)
				precedence: 2
				from: encoder.
			^true]
		ifFalse: 
			[^false]