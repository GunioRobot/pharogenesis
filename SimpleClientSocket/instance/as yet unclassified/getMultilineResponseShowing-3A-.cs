getMultilineResponseShowing: showFlag
	"Get a multiple line response to the last command. A multiple line response ends with a line containing only a single period (.) character. Linefeed characters are filtered out. If showFlag is true, each line is shown in the upper-left corner of the Display as it is received."

	| response done chunk |
	response _ WriteStream on: ''.
	done _ false.
	[done] whileFalse: [
		showFlag
			ifTrue: [chunk _ self getResponseShowing: true]
			ifFalse: [chunk _ self getResponse].
		(chunk beginsWith: '.')
			ifTrue: [ response nextPutAll: (chunk copyFrom: 2 to: chunk size) ]
			ifFalse: [ response nextPutAll: chunk ].
		done _ (chunk = ('.', String cr)) ].

	^ response contents
