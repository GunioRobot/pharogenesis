initReservedScriptNames
	"Initialize the ReservedScriptNames class var, by polling the classes that have defined viewer-category information"

	| additions aSet |
	"ScriptingSystem initReservedScriptNames"
	aSet _ IdentitySet new.
	Morph withAllSubclasses do:
		[:aClass |
			(aClass class includesSelector: #additionsToViewerCategories) ifTrue:
				[additions _ aClass additionsToViewerCategories.
				additions do:
					[:catNameAndInfo |
						catNameAndInfo second do:
							[:spec | (spec first == #command) ifTrue:
								[aSet add: spec second]]]]].

	ReservedScriptNames _ aSet