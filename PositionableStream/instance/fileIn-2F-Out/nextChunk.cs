nextChunk
	"Answer the contents of the receiver, up to the next terminator character.
	Imbedded terminators are doubled."
	| terminator segment |
	terminator _ $!.
	self skipSeparators.
	segment _ self upTo: terminator.
	[self peekFor: terminator] whileTrue:   "case of imbedded (doubled) terminator"
			[segment _ (segment copyWith: terminator) , (self upTo: terminator)].
	^ segment