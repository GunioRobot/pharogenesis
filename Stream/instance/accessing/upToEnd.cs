upToEnd
	"answer the remaining elements in the string"
	| elements |
	elements _ OrderedCollection new.
	[ self atEnd ] whileFalse: [ 
		elements add: self next ].
	^elements