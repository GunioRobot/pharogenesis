actualTextStyles
	| aDict |
	"TextStyle actualTextStyles"

	"Answer dictionary whose keys are the names of styles in the system and whose values are the actual styles"

	aDict _ TextConstants select: [:thang | thang isKindOf: self ].
	self defaultFamilyNames do: [ :sym | aDict removeKey: sym ].
	^ aDict