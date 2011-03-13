addClassSender: sendingSelector of: sentSelector
	| senders |
	senders _ classSenders at: sentSelector ifAbsent: [#()].
	classSenders at: sentSelector put: (senders copyWith: sendingSelector).