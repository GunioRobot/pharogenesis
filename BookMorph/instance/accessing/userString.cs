userString
	"Do I have a text string to be searched on?"

	| list |
	self getAllText.
	list _ OrderedCollection new.
	(self valueOfProperty: #allText ifAbsent: #()) do: [:aList |
		list addAll: aList].
	^ list