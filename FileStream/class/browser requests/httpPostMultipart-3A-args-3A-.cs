httpPostMultipart: url args: argsDict
	| mimeBorder argsStream crLf fieldValue resultStream result |
	" do multipart/form-data encoding rather than x-www-urlencoded "

	crLf _ String crlf.
	mimeBorder _ '----squeak-', Time millisecondClockValue printString, '-stuff-----'.
	"encode the arguments dictionary"
	argsStream _ WriteStream on: String new.
	argsDict associationsDo: [:assoc |
		assoc value do: [ :value |
		"print the boundary"
		argsStream nextPutAll: '--', mimeBorder, crLf.
		" check if it's a non-text field "
		argsStream nextPutAll: 'Content-disposition: form-data; name="', assoc key, '"'.
		(value isKindOf: MIMEDocument)
			ifFalse: [fieldValue _ value]
			ifTrue: [argsStream nextPutAll: ' filename="', value url pathForFile, '"', crLf, 'Content-Type: ', value contentType.
				fieldValue _ (value content
					ifNil: [(FileStream fileNamed: value url pathForFile) contentsOfEntireFile]
					ifNotNil: [value content]) asString].
" Transcript show: 'field=', key, '; value=', fieldValue; cr. "
		argsStream nextPutAll: crLf, crLf, fieldValue, crLf.
	]].
	argsStream nextPutAll: '--', mimeBorder, '--'.

	resultStream _ self
		post: 
			('Content-type: multipart/form-data; boundary=', mimeBorder, crLf,
			'Content-length: ', argsStream contents size printString, crLf, crLf, 
			argsStream contents)
		url: url ifError: [^'Error in post ' url toText].
	"get the header of the reply"
	result _ resultStream upToEnd.
	^MIMEDocument content: result