parseParts
	"private -- parse the parts of the message and put them in the parts ivar.  If this is not a multipart message, put #() into the ivar"
	| parseStream currLine msgStream messages |
	self body isMultipart ifFalse: [^ parts _ #()].
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
	parts _ messages collect: [:e | MailMessage from: e]