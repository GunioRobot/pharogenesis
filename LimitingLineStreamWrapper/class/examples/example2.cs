example2
	"LimitingLineStreamWrapper example2"
	"Demo nesting wrappers - get header lines from some messages"
	| inStream msgStream headers headerStream |
	inStream _ self exampleStream.
	msgStream _ LimitingLineStreamWrapper on: inStream delimiter: 'From '.
	headers _ OrderedCollection new.
	[inStream atEnd] whileFalse: [
		msgStream skipThisLine. "Skip From"
		headerStream _ LimitingLineStreamWrapper on: msgStream delimiter: ''.
		headers add: headerStream linesUpToEnd.
		[msgStream nextLine isNil] whileFalse. "Skip Body"
	].
	^headers
			