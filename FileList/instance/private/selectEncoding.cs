selectEncoding

	| aMenu encodingItems |
	aMenu := CustomMenu new.
	encodingItems := OrderedCollection new.
	TextConverter allSubclasses do: [:each | | names |
		names := each encodingNames.
		names notEmpty ifTrue: [ | label |
			label := '' writeStream.
			names do: [:eachName | label nextPutAll: eachName ] separatedBy: [ label nextPutAll: ', '].
			encodingItems add: {label contents. names first asSymbol}.
		].
	].
	aMenu addList: encodingItems.
	brevityState := aMenu startUp.
	brevityState ifNil: [brevityState := #needToGetBrief].
