parts
	| divider |
	"return the parts of speech this word can be.  Keep the streams for each"
	parts _ OrderedCollection new.
	partStreams _ OrderedCollection new.
	rwStream ifNil: [self stream].
	rwStream reset.
	rwStream match: 'Palavra desconhecida pelo Dicion·rio.'.
	rwStream atEnd ifFalse: [^ #()].	"not in dictionary"

	rwStream reset.
	rwStream match: (divider _ '<li>').	"stemming a complex word"
	rwStream atEnd ifTrue: [rwStream reset.
		rwStream match: (divider _ '<dd>')].	"base word in dict"
	[rwStream atEnd] whileFalse: [
		partStreams add: (ReadStream on: (rwStream upToAll: divider))].
	partStreams do: [:pp |
		parts add: (pp upToAll: '</b>')].
	parts size = 0 ifTrue: [^ parts].
	parts last = '' ifTrue: [parts removeLast.  partStreams removeLast].
		"May want to remove all after </dl>"
	^ parts 