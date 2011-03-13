into: leafDict fromSender: senderTally
	| leafNode |
	leafNode _ leafDict at: method
		ifAbsent: [leafDict at: method
			put: (MessageTally new class: class method: method)].
	leafNode bump: tally fromSender: senderTally