evalEmbedded: string with: request unlessContains: dangerSet
	dangerSet do: [:each | (string includesSubstring: each caseSensitive: false)
		ifTrue: [^'Unsafe code!']].
	^self evalEmbedded: string with: request
