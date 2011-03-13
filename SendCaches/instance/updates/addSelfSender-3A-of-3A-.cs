addSelfSender: sendingSelector of: sentSelector
	| senders |
	senders := selfSenders at: sentSelector ifAbsent: [#()].
	selfSenders at: sentSelector put: (senders copyWith: sendingSelector).