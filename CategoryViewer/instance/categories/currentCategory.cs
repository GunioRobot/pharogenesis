currentCategory
	"Temporarily switch-hits in support of two competing ui designs for the list"
	| current actualPane |
	actualPane _ namePane renderedMorph.
	current _ (actualPane isKindOf: PluggableListMorph)
		ifTrue:
			[actualPane selection]
		ifFalse:
			[(actualPane isKindOf: StringMorph)
				ifTrue:	[actualPane contents]
				ifFalse:	[actualPane firstSubmorph contents]].
	^ current ifNil: [#basic]