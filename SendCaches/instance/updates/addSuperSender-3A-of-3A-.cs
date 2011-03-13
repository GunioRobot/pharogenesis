addSuperSender: sendingSelector of: sentSelector
	| senders |
	senders _ superSenders at: sentSelector ifAbsent: [#()].
	superSenders at: sentSelector put: (senders copyWith: sendingSelector).