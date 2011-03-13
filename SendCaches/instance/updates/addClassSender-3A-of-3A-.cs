addClassSender: sendingSelector of: sentSelector
	| senders |
	senders := classSenders at: sentSelector ifAbsent: [#()].
	classSenders at: sentSelector put: (senders copyWith: sendingSelector).