initStandardScriptInfo
	"Initialize the data structure that characterizes, for the etoy system, the built-in system scripts.  The structure is a dictionary whose keys are the script selectors and whose values are arrays of one of the forms:
              (command   <selector>)
              (command   <selector>  <argType>)
The structure is built up by letting every Morph subclass contribute elements simply by implementing method #scriptInfo.  Consult implementors of #scriptInfo for examples of how this goes."

	"ScriptingSystem initStandardScriptInfo"

	| aDictionary |
	aDictionary _ Dictionary new.  
	"For safety, the new copy is built up in this temp first, so that if an error occurs during the creation of the structure, the old version will remain remain in place"

	Morph withAllSubclasses do:
		[:aClass | (aClass class selectors includes: #scriptInfo)
			ifTrue:
				[aClass scriptInfo do:
					[:anArray | aDictionary at: anArray second put: anArray]]].

	StandardScriptInfo _ aDictionary