selectEncoding

	| aMenu encodingItems |
	aMenu _ CustomMenu new.
	encodingItems _ OrderedCollection new.
	TextConverter allSubclasses do: [:each | | names |
		names _ each encodingNames.
		names notEmpty ifTrue: [ | label |
			label _ '' writeStream.
			names do: [:eachName | label nextPutAll: eachName ] separatedBy: [ label nextPutAll: ', '].
			encodingItems add: {label contents. names first asSymbol}.
		].
	].
	aMenu addList: encodingItems.
	brevityState _ aMenu startUp.
	brevityState ifNil: [brevityState _ #needToGetBrief].
