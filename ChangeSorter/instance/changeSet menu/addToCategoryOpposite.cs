addToCategoryOpposite
	"Add the current change set to the category viewed on the opposite side, if it's of the sort to accept things like that"

	| categoryOpposite |
	categoryOpposite := (parent other: self) changeSetCategory.
	categoryOpposite acceptsManualAdditions
		ifTrue:
			[categoryOpposite addChangeSet: myChangeSet.
			categoryOpposite reconstituteList.
			self update]
		ifFalse:
			[self inform: 
'sorry, this command only makes sense
if the category showing on the opposite
side is a static category whose
members are manually maintained']