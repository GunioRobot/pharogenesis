commit
	self cleanBetween: stack first key and: stack last key.
	self points addAll: stack.
	stack := SortedCollection new