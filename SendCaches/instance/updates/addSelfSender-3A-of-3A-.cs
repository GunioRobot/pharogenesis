addSelfSender: sendingSelector of: sentSelector
	| senders |
	senders _ selfSenders at: sentSelector ifAbsent: [#()].
	selfSenders at: sentSelector put: (senders copyWith: sendingSelector).