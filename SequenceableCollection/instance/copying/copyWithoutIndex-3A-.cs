copyWithoutIndex: index
	| copy |
	"return a copy containing all elements except the index-th"
	copy := self species new: self size - 1.
	copy replaceFrom: 1 to: index-1 with: self startingAt: 1.
	copy replaceFrom: index to: copy size with: self startingAt: index+1.
	^copy