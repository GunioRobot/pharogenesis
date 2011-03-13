initializeSystemSlotDictionary
	"Initialize a structure that gives names and types for all the slots and pseudo-slots defined in the current scripting vocabulary.  The keys to this dictionary are slot-name-symbols, and the values are value-type-symbols"

	| aDictionary additions |
	"ScriptingSystem initializeSystemSlotDictionary"
	aDictionary _ IdentityDictionary new.
	Morph withAllSubclasses do:
		[:aClass |
			(aClass class includesSelector: #additionsToViewerCategories) ifTrue:
				[additions _ aClass additionsToViewerCategories.
				additions do:
					[:catNameAndInfo |
						catNameAndInfo second do:
							[:spec | (spec first == #slot) ifTrue:
								[aDictionary at: spec second put: spec fourth]]]]].

	SystemSlotDictionary _ aDictionary