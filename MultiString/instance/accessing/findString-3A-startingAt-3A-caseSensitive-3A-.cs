findString: key startingAt: start caseSensitive: caseSensitive
	"Answer the index in this String at which the substring key first occurs, at or beyond start.  The match can be case-sensitive or not.  If no match is found, zero will be returned."

	^ caseSensitive ifTrue: [
		self
			findMultiSubstring: key asMultiString
			in: self
			startingAt: start
			matchTable: nil.
	] ifFalse: [
		self
			findMultiSubstring: key asLowercase asMultiString
			in: self asLowercase
			startingAt: start
			matchTable: nil.
	].
