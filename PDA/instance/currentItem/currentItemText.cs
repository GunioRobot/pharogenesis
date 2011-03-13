currentItemText

	currentItem ifNil: [^ 'no item is selected'].
	viewDescriptionOnly
		ifTrue: [currentItem description ifNil:
					[^ 'No description has yet been entered for this item'].
				^ currentItem description asText]
		ifFalse: [^ currentItem asText]