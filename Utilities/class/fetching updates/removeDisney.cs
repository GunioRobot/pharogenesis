removeDisney
	"remove the Disney server from the update lists.  For external release."

	UpdateUrlLists copy do: [:pair |
		(pair first includesSubstring: 'Disney' caseSensitive: false) ifTrue: [
			UpdateUrlLists remove: pair]].
	Smalltalk removeKey: #UpdatesAtDOL ifAbsent: [].
	Smalltalk removeKey: #UpdatesAtWebPage ifAbsent: [].

