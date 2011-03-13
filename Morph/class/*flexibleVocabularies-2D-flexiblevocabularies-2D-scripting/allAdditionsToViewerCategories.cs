allAdditionsToViewerCategories
	"Answer a Dictionary of (<categoryName> <list of category specs>) that 
	defines the phrases this kind of morph wishes to add to various Viewer categories. 
	 
	This version allows each category definition to be defined in one or more separate methods. 
	 
	Subclasses that have additions can either:
	- override #additionsToViewerCategories, or
	- (preferably) define one or more additionToViewerCategory* methods.

	The advantage of the latter technique is that class extensions may be added by
	external packages without having to re-define additionsToViewerCategories."

	"
	Morph allAdditionsToViewerCategories
	"
	| dict |
	dict := IdentityDictionary new.
	(self class includesSelector: #additionsToViewerCategories)
		ifTrue: [self additionsToViewerCategories
				do: [:group | group
						pairsDo: [:key :list | (dict
								at: key
								ifAbsentPut: [OrderedCollection new])
								addAll: list]]].
	self class selectors
		do: [:aSelector | ((aSelector beginsWith: 'additionsToViewerCategory')
					and: [(aSelector at: 26 ifAbsent: []) ~= $:])
				ifTrue: [(self perform: aSelector)
						pairsDo: [:key :list | (dict
								at: key
								ifAbsentPut: [OrderedCollection new])
								addAll: list]]].
	^ dict