forSaveDirectory: aDirectory
	| universe |
	universe _ self forUniverse: UUniverse new.
	universe saveDirectory: aDirectory.
	universe loadFromCheckpoint.
	^universe