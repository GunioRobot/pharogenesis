personalSlotNamesAndTypesForBank: aBank
	"Return an array of slot names and slot info for use in a viewer on the receiver"

	| nameString |
	aBank ~~ 1 ifTrue: [^ Array new].

	^ self slotNames collect: [:aName |
		nameString _ aName asString capitalized.
		Array
			with: 	aName 								"name"
			with: 	(self typeForSlot: aName asSymbol)	"type"
			with:	#readWrite							"r/w"
			with:	('get', nameString) asSymbol		"get selector"
			with:	('set', nameString, ':') asSymbol]	"set selector"