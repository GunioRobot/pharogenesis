getValueAtCursor
	| costumeToUse anObject renderedMorph |

	costumeToUse _ ((renderedMorph _ costume renderedMorph) respondsTo: #valueAtCursor) 
		ifTrue:
			[renderedMorph]
		ifFalse:
			[self costumeNamed: #PasteUpMorph].

	anObject _ costumeToUse valueAtCursor.
	^ anObject == 0  "weird return from Holder & Graph"
		ifTrue:
			[nil]
		ifFalse:
			[anObject assuredCostumee]