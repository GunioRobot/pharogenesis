parseParts
	| parseStream currLine msgStream messages |
	self isMultipart ifFalse: [^ parts _ #()].
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
	parts _ messages collect: [:e | MIMEPart on: e]