initCategoryElementDictionary
	"Initialize the data structure that characterizes, for the etoy system, which elements fall into which categories in the Viewer.

The structure is built up by letting every Morph subclass contribute elements simply by implementing method #categoryContributions.  Consult implementors of #categoryContributions for examples of how this goes."

	"ScriptingSystem initCategoryElementDictionary"

	| aDictionary |
	aDictionary _ Dictionary new.  
	"For safety, the new copy is built up in this temp first, so that if an error occurs during the creation of the structure, the old version will remain remain in place"

	Morph withAllSubclasses do:
		[:aClass | (aClass class selectors includes: #categoryContributions)
			ifTrue:
				[aClass categoryContributions do:
					[:pair | aDictionary at: pair first put: pair second]]].

	CategoryElementDictionary _ aDictionary