initializeFor: aPlayer categoryChoice: aChoice
	"Initialize the receiver to be associated with the player and category specified"

	super initializeFor: aPlayer categoryChoice: #search.
	(namePane findA: PluggableTextMorph) setText: aChoice second asText.
	self setCategorySymbolFrom: aChoice