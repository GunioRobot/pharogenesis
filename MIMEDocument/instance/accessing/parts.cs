parts

	"Return the parts of this message.  There is a far more reliable implementation of parts in MailMessage, but for now we are continuing to use this implementation"

	| parseStream currLine separator msgStream messages |
	self isMultipart ifFalse: [^ #()].
	parseStream _ ReadStream on: self content.
	currLine _ ''.
	['--*' match: currLine]
		whileFalse: [currLine _ parseStream nextLine].
	separator _ currLine copy.
	msgStream _ LimitingLineStreamWrapper on: parseStream delimiter: separator.
	messages _ OrderedCollection new.
	[parseStream atEnd]
		whileFalse: 
			[messages add: msgStream upToEnd.
			msgStream skipThisLine].
	^ messages collect: [:e | MailMessage from: e]
