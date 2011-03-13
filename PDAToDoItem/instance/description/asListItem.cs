asListItem

	^ (priority ifNil: [0]) printString , ' ' , super asListItem