items
	(target notNil and: [getItemsSelector notNil])
		ifTrue: [items _ target perform: getItemsSelector withArguments: getItemsArgs].
	items ifNil: [items _ #()].
	^items