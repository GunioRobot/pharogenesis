initStandardSlotInfo
	"Initialize the data structure that characterizes, for the etoy system, the built-in pseudoslots.  The structure is a dictionary whose keys are the slot names and whose values are arrays of quintuplets exemplified by:

	(borderColor		color		readWrite	getBorderColor	setBorderColor:)

The structure is built up by letting every Morph subclass contribute elements simply by implementing method #standardSlotInfo.  Consult implementors of #standardSlotInfo for examples of how this goes."

	"ScriptingSystem initStandardSlotInfo"

	| aDictionary |
	aDictionary _ Dictionary new.  
	"For safety, the new copy is built up in this temp first, so that if an error occurs during the creation of the structure, the old version will remain remain in place"

	Morph withAllSubclasses do:
		[:aClass | (aClass class selectors includes: #standardSlotInfo)
			ifTrue:
				[aClass standardSlotInfo do:
					[:anArray | aDictionary at: anArray first put: anArray]]].

	StandardSlotInfo _ aDictionary