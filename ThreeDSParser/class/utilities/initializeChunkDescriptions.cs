initializeChunkDescriptions
	"Initialize Class variable ChunkDescriptions from the documentation"
	"ThreeDSParser initializeChunkDescriptions "

	| s id tag comment sl c |
	s := ReadStream on: self chunkDocumentation.
	ChunkDescriptions := Dictionary new: 100.
	id := tag := comment := nil.
	[s atEnd] whileFalse: [
		s peek = Character tab
			ifFalse: [
				id isNil ifFalse: [
					ChunkDescriptions add: (ThreeDSChunkDescription
						id: id name: tag comment: comment contents)].
				id := Integer readFrom: s base: 16.
				s skip: 2.
				sl := ReadStream on: (s upTo: Character cr).
				tag := OrderedCollection new.
				[(c := sl next) isNil or: [c isSeparator]] whileFalse: [tag add: c].
				tag := String withAll: tag.
				sl skipSeparators.
				comment := WriteStream on: String new]
			ifTrue: [comment nextPutAll: s nextLine; nextPut: Character cr]
		].
	ChunkDescriptions add: (ThreeDSChunkDescription
						id: id name: tag comment: comment contents)