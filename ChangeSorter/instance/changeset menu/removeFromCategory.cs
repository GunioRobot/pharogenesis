removeFromCategory
	"Add the current change set to the category viewed on the opposite side, if it's of the sort to accept things like that"

	| aCategory |
	(aCategory := self changeSetCategory) acceptsManualAdditions
		ifTrue:
			[aCategory removeElementAt: myChangeSet name.
			aCategory reconstituteList.
			self update]
		ifFalse:
			[self inform: 
'sorry, this command only makes
sense for static categories whose
members are manually maintained']