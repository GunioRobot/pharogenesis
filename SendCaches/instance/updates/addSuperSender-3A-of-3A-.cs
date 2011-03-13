addSuperSender: sendingSelector of: sentSelector
	| senders |
	senders := superSenders at: sentSelector ifAbsent: [#()].
	superSenders at: sentSelector put: (senders copyWith: sendingSelector).