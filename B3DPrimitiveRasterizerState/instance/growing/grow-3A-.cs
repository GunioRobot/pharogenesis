grow: anArray
	| newArray |
	newArray _ anArray species new: anArray size + (anArray size // 4 max: 100).
	newArray replaceFrom: 1 to: anArray size with: anArray startingAt: 1.
	^newArray