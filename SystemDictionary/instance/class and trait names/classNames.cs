classNames
	"Answer a SortedCollection of all class names."
	| names |
	cachedClassNames == nil ifTrue:
		[names := OrderedCollection new: self size.
		self do: 
			[:cl | (cl isInMemory
				and: [(cl isKindOf: Class)
					and: [(cl name beginsWith: 'AnObsolete') not]])
				ifTrue: [names add: cl name]].
		cachedClassNames := names asSortedCollection].
	^ cachedClassNames