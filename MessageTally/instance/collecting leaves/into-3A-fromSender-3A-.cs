into: leafDict fromSender: senderTally
	| leafNode |
	leafNode := leafDict at: method
		ifAbsent: [leafDict at: method
			put: ((MessageTally new class: class method: method)
				process: process;
				reportOtherProcesses: reportOtherProcesses)].
	leafNode bump: tally fromSender: senderTally