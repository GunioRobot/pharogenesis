traitNames
	"Answer a SortedCollection of all traits (not including class-traits) names."
	| names |
	names := OrderedCollection new.
	self do: 
		[:cl | (cl isInMemory
			and: [(cl isKindOf: Trait)
			and: [(cl name beginsWith: 'AnObsolete') not]])
				ifTrue: [names add: cl name]].
	^ names