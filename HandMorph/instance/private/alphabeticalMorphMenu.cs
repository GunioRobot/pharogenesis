alphabeticalMorphMenu

	| list splitLists menu firstChar lastChar subMenu |
	list _ Morph withAllSubclasses select:[:m | m includeInNewMorphMenu].
	list _ list asArray sortBy:[:c1 :c2| c1 name < c2 name].
	splitLists _ self splitNewMorphList: list depth: 3.
	menu _ MenuMorph new defaultTarget: self.
	1 to: splitLists size do:[:i|
		i = 1 ifTrue:[firstChar _ $A]
			ifFalse:[firstChar _ ((splitLists at: i-1) last name first asInteger + 1) asCharacter].
		i = splitLists size
			ifTrue:[lastChar _ $Z]
			ifFalse:[lastChar _ (splitLists at: i) last name first].
		subMenu _ MenuMorph new.
		(splitLists at: i) do:[:cl|
			subMenu add: cl name
					target: self
					selector: #newMorphOfClass:event:
					argument: cl].
		menu add: firstChar asString,' - ', lastChar asString subMenu: subMenu.
	].
	^menu