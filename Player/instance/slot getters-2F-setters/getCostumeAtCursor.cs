getCostumeAtCursor
	"Answer the form representing the object at the current cursor.  An earlier wording, disused but may persist in preexisting scripts"

	| anObject aMorph |
	
	anObject _ self getValueFromCostume: #valueAtCursor.
	^ anObject == 0  "weird return from GraphMorph"
		ifTrue:
			[ScriptingSystem formAtKey: #Paint]
		ifFalse:
			[((aMorph _ anObject renderedMorph) isSketchMorph)
				ifTrue:
					[aMorph form]
				ifFalse:
					[anObject imageForm]]