buildFamilies
	| familyNames family |
	families := Dictionary new.
	familyNames :=	(fileInfos collect:[:each | each familyGroupName]) asSet asSortedCollection asArray.
	familyNames do:[:familyName |
		family := self buildFamilyNamed: familyName.
		families at: familyName put: family].
	
	
	
	