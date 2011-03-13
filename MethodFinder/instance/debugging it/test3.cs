test3
	"find the modification of the caracter table"

	(#x at: 1) asciiValue = 120 ifFalse: [self error: 'Character table mod'].