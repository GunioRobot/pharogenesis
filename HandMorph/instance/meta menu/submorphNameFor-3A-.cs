submorphNameFor: aMorph

	| s nameInModel |
	(s _ aMorph knownName) ifNotNil: [^ s].

	s _ aMorph class name asString.
	nameInModel _ aMorph specialNameInModel.
	nameInModel ifNotNil: [s _ s, ' "', nameInModel, '"'].
	^ s
