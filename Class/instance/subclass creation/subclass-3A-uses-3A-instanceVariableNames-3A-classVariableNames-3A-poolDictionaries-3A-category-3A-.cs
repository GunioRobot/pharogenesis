subclass: t uses: aTraitCompositionOrArray instanceVariableNames: f classVariableNames: d poolDictionaries: s category: cat 
	| newClass copyOfOldClass |
	copyOfOldClass _ self copy.
	newClass _ self
		subclass: t
		instanceVariableNames: f
		classVariableNames: d
		poolDictionaries: s
		category: cat.
		
	
	newClass setTraitComposition: aTraitCompositionOrArray asTraitComposition.
	SystemChangeNotifier uniqueInstance
		classDefinitionChangedFrom: copyOfOldClass to: newClass.
	^newClass