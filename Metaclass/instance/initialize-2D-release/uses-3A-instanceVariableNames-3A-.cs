uses: aTraitCompositionOrArray instanceVariableNames: instVarString 
	| newComposition newMetaClass copyOfOldMetaClass |
	
	copyOfOldMetaClass _ self copy.
	newMetaClass _ self instanceVariableNames: instVarString.
	
	newComposition _ aTraitCompositionOrArray asTraitComposition.
	newMetaClass assertConsistantCompositionsForNew: newComposition.
	newMetaClass setTraitComposition: newComposition.
	
	SystemChangeNotifier uniqueInstance
		classDefinitionChangedFrom: copyOfOldMetaClass to: newMetaClass