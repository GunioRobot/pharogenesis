classNames
	"Answer a SortedCollection of all class names."
	| names |
	CachedClassNames == nil ifTrue:
		[names _ OrderedCollection new: self size.
		self do: 
			[:cl | (cl isKindOf: Class) ifTrue: [names add: cl name]].
		CachedClassNames _ names asSortedCollection].
	^ CachedClassNames