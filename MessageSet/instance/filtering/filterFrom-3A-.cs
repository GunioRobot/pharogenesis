filterFrom: aBlock
	"Filter the receiver's list down to only those items that satisfy aBlock, which takes a class an a selector as its arguments."

	| newList |
	newList _ messageList select:
		[:anElement |
			self class parse: anElement toClassAndSelector: aBlock].
	self setFilteredList: newList