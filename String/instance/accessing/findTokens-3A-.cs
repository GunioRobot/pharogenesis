findTokens: delimiters
	"Answer the collection of tokens that result from parsing self.  Any character in the String delimiters marks a border.  Several delimiters in a row are considered as just one separation."

	| tokens keyStart keyStop |

	tokens _ OrderedCollection new.
	keyStop _ 1.
	[keyStop <= self size] whileTrue:
		[keyStart _ self skipDelimiters: delimiters startingAt: keyStop.
		keyStop _ self findDelimiters: delimiters startingAt: keyStart.
		keyStart < keyStop
			ifTrue: [tokens add: (self copyFrom: keyStart to: (keyStop - 1))]].
	^tokens