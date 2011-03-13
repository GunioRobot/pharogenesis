commandLine: aString
	"Start up this launcher from within Squeak as if it Squeak been launched the given command line."

	| dict tokens cmd arg |
	dict _ Dictionary new.
	tokens _ ReadStream on: (aString findTokens: ' ').
	[cmd _ tokens next.
	 arg _ tokens next.
	 ((cmd ~~ nil) and: [arg ~~ nil])]
		whileTrue: [dict at: cmd put: arg].
	self parameters: dict.
	self startUp.
