findCategoryFromPreference: prefSymbol
	"Find all categories in which the preference occurs"

	| aMenu| 
	aMenu _ MenuMorph new defaultTarget: self.
	(Preferences categoriesContainingPreference: prefSymbol) do:
		[:aCategory | aMenu add: aCategory target: self selector: #switchToCategoryNamed:event: argumentList: {aCategory. MorphicEvent new}].
	aMenu popUpInWorld