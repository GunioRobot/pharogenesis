startingAt: keyStart match: text startingAt: textStart
	"Answer whether text matches the pattern in this string.
	Matching ignores upper/lower case differences.
	Where this string contains #, text may contain any character.
	Where this string contains *, text may contain any sequence of characters."
	| anyMatch matchStart matchEnd i matchStr j ii jj |
	i _ keyStart.
	j _ textStart.

	"Check for any #'s"
	[i > self size ifTrue: [^ j > text size "Empty key matches only empty string"].
	(self at: i) = $#] whileTrue:
		["# consumes one char of key and one char of text"
		j > text size ifTrue: [^ false "no more text"].
		i _ i+1.  j _ j+1].

	"Then check for *"
	(self at: i) = $*
		ifTrue: [i = self size ifTrue:
					[^ true "Terminal * matches all"].
				"* means next match string can occur anywhere"
				anyMatch _ true.
				matchStart _ i + 1]
		ifFalse: ["Otherwise match string must occur immediately"
				anyMatch _ false.
				matchStart _ i].

	"Now determine the match string"
	matchEnd _ self size.
	(ii _ self indexOf: $* startingAt: matchStart) > 0 ifTrue:
		[ii = 1 ifTrue: [self error: '** not valid -- use * instead'].
		matchEnd _ ii-1].
	(ii _ self indexOf: $# startingAt: matchStart) > 0 ifTrue:
		[ii = 1 ifTrue: [self error: '*# not valid -- use #* instead'].
		matchEnd _ matchEnd min: ii-1].
	matchStr _ self copyFrom: matchStart to: matchEnd.

	"Now look for the match string"
	[jj _ text findString: matchStr startingAt: j caseSensitive: false.
	anyMatch ifTrue: [jj > 0] ifFalse: [jj = j]]
		whileTrue:
		["Found matchStr at jj.  See if the rest matches..."
		(self startingAt: matchEnd+1 match: text startingAt: jj + matchStr size) ifTrue:
			[^ true "the rest matches -- success"].
		"The rest did not match."
		anyMatch ifFalse: [^ false].
		"Preceded by * -- try for a later match"
		j _ j+1].
	^ false "Failed to find the match string"