actualTextStyles
	| aDict |
	"Utilities actualTextStyles"

	"Answer dictionary whose keys are the names of styles in the system and whose values are the actual styles"

	aDict _ TextConstants select: [:thang | thang isKindOf: TextStyle].
	aDict removeKey: #DefaultTextStyle.
	^ aDict