makeNewPlayfield
	| aPlayfield names aKey |
	aPlayfield _ PasteUpMorph new.
	names _ associatedMorph allSubmorphNames.
	aKey _ Utilities keyLike: 'playfield' satisfying:
		[:aName | (names includes: aKey) not].
	aPlayfield setNameTo: aKey.
	aPlayfield color: Color green muchLighter; borderWidth: 2; 
		borderColor: Color green;
		extent: 250 @ 200.
	associatedMorph primaryHand attachMorph: aPlayfield