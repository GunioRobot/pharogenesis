classComment: aString stamp: aStamp
	"Store the comment, aString or Text or RemoteString, associated with the class we are organizing.  Empty string gets stored only if had a non-empty one before."

	| ptr header file oldCommentRemoteStr |
	(aString isKindOf: RemoteString) ifTrue:
		[SystemChangeNotifier uniqueInstance classCommented: self.
		^ self organization classComment: aString stamp: aStamp].

	oldCommentRemoteStr _ self organization commentRemoteStr.
	(aString size = 0) & (oldCommentRemoteStr == nil) ifTrue: [^ self organization classComment: nil].
		"never had a class comment, no need to write empty string out"

	ptr _ oldCommentRemoteStr ifNil: [0] ifNotNil: [oldCommentRemoteStr sourcePointer].
	SourceFiles ifNotNil: [(file _ SourceFiles at: 2) ifNotNil:
		[file setToEnd; cr; nextPut: $!.	"directly"
		"Should be saying (file command: 'H3') for HTML, but ignoring it here"
		header _ String streamContents: [:strm | strm nextPutAll: self name;
			nextPutAll: ' commentStamp: '.
			aStamp storeOn: strm.
			strm nextPutAll: ' prior: '; nextPutAll: ptr printString].
		file nextChunkPut: header]].
	self organization classComment: (RemoteString newString: aString onFileNumber: 2) stamp: aStamp.
	SystemChangeNotifier uniqueInstance classCommented: self.
