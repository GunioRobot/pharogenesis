errorReportOn: strm
	"Write a detailed error report on the stack (above me) on a stream.  For both the error file, and emailing a bug report.  Suppress any errors while getting printStrings.  Limit the length."

	| cnt aContext startPos |
 	strm print: Date today; space; print: Time now; cr.
	strm cr.
	strm nextPutAll: 'VM: ';
		nextPutAll:  SmalltalkImage current platformName asString;
		nextPutAll: ' - ';
		nextPutAll: SmalltalkImage current asString;
		cr.
	strm nextPutAll: 'Image: ';
		nextPutAll:  SystemVersion current version asString;
		nextPutAll: ' [';
		nextPutAll: SmalltalkImage current lastUpdateString asString;
		nextPutAll: ']';
		cr.
	strm cr.
	SecurityManager default printStateOn: strm.
	
	"Note: The following is an open-coded version of ContextPart>>stackOfSize: since this method may be called during a low space condition and we might run out of space for allocating the full stack."
	cnt _ 0.  startPos _ strm position.
	aContext _ self.
	[aContext notNil and: [(cnt _ cnt + 1) < 5]] whileTrue:
		[aContext printDetails: strm.	"variable values"
		strm cr.
		aContext _ aContext sender].

	strm cr; nextPutAll: '--- The full stack ---'; cr.
	aContext _ self.
	cnt _ 0.
	[aContext == nil] whileFalse:
		[cnt _ cnt + 1.
		cnt = 5 ifTrue: [strm nextPutAll: ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -'; cr].
		strm print: aContext; cr.  "just class>>selector"	

		strm position > (startPos+4000) ifTrue: [strm nextPutAll: '...etc...'.
			^ self]. 	"exit early"
		cnt > 60 ifTrue: [strm nextPutAll: '-- and more not shown --'.  ^ self].
		aContext _ aContext sender].
