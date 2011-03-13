classCommentBlank

	| existingComment stream |
	existingComment := self theNonMetaClass organization classComment.
	existingComment isEmpty
		ifFalse: [^existingComment].

	stream := WriteStream on: (String new: 100).
	stream
		nextPutAll: 'A';
		nextPutAll: (self name first isVowel ifTrue: ['n '] ifFalse: [' ']);
		nextPutAll: self name;
		nextPutAll: ' is xxxxxxxxx.';
		cr; cr;
		nextPutAll: 'Instance Variables'.

	self instVarNames asSortedCollection do: [:each |
		stream
			cr; tab; nextPutAll: each;
			nextPut: $:;
			tab; tab;
			nextPutAll: '<Object>'].

	stream cr.
	self instVarNames asSortedCollection do: [:each |
		stream
			cr; nextPutAll: each;
			cr; tab; nextPutAll: '- xxxxx'; cr].

	^stream contents