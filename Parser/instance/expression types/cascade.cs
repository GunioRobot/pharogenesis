cascade
	" {; message} => CascadeNode."

	| rcvr msgs |
	parseNode canCascade
		ifFalse: [^self expected: 'Cascading not'].
	rcvr := parseNode cascadeReceiver.
	msgs := OrderedCollection with: parseNode.
	[self match: #semicolon]
		whileTrue: 
			[parseNode := rcvr.
			(self messagePart: 3 repeat: false)
				ifFalse: [^self expected: 'Cascade'].
			parseNode canCascade
				ifFalse: [^self expected: '<- No special messages'].
			parseNode cascadeReceiver.
			msgs addLast: parseNode].
	parseNode := CascadeNode new receiver: rcvr messages: msgs