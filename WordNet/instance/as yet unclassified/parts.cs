parts
	"return the parts of speech this word can be.  Keep the streams for each"
	parts _ OrderedCollection new.
	partStreams _ OrderedCollection new.
	rwStream ifNil: [self stream].
	rwStream reset.
	rwStream match: '<HR>'.
	[rwStream atEnd] whileFalse: [
		partStreams add: (ReadStream on: (rwStream upToAll: '<HR>'))].
	partStreams do: [:pp |
		parts add: (self partOfSpeechIn: pp)].
	parts last = '' ifTrue: [parts removeLast.  partStreams removeLast].
	^ parts 