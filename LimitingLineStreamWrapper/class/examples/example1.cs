example1
	"LimitingLineStreamWrapper example1"
	"Separate chunks of text delimited by a special string"
	| inStream msgStream messages |
	inStream _ self exampleStream.
	msgStream _ LimitingLineStreamWrapper on: inStream delimiter: 'From '.
	messages _ OrderedCollection new.
	[inStream atEnd] whileFalse: [
		msgStream skipThisLine.
		messages add: msgStream upToEnd].
	^messages
			