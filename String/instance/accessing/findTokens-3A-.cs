findTokens: delimiters

	"Answer the collection of tokens that result from parsing self.  The tokens are seperated by delimiters, any of a string of characters."

	| tokens keyStart keyStop |

	tokens _ OrderedCollection new.
	keyStop _ 1.
	[keyStop <= self size] whileTrue:
		[keyStart _ self skipDelimiters: delimiters startingAt: keyStop.
		keyStop _ self findDelimiters: delimiters startingAt: keyStart.
		keyStart < keyStop
			ifTrue: [tokens add: (self copyFrom: keyStart to: (keyStop - 1))]].
	^tokens