isPvtSelector | prefix prefixSize |
	"Answer whether the receiver is a private message selector, that is, begins with 'pvt' followed by an uppercase letter, e.g. pvtStringhash."

	prefix _ 'pvt'.
	prefixSize _ prefix size.

	self size <= prefixSize ifTrue: [^false].
	1 to: prefixSize do:
		[:index | (self at: index) = (prefix at: index) ifFalse: [^false]].
	^(self at: prefixSize + 1) isUppercase