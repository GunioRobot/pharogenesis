prototypicalHolder
	| aHolder |
	aHolder := PasteUpMorph authoringPrototype color: Color orange muchLighter; borderColor: Color orange lighter.
	aHolder setNameTo: 'holder'; extent: 160 @ 110.
	^ aHolder behaveLikeHolder.
