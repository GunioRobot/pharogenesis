tilePhrasesSpecsForCategory: aCategory
	"Return an array of slot and script names and info for use in a viewer on the receiver.  These can be of two flavors - script and slot.

		(slot		heading		number				readWrite	getHeading		setHeading:)
		(script		command 	wearCostumeOf: 	player)"

	| aList nameString categoryString |
	categoryString _ aCategory asString.
	(categoryString = 'instance variables') ifTrue:
		[^ self slotNames collect: [:aName |
		nameString _ aName asString capitalized.
		Array
			with:	#slot
			with: 	aName asSymbol					"name"
			with: 	(self typeForSlot: aName asSymbol)	"type"
			with:	#readWrite							"r/w"
			with:	('get', nameString) asSymbol		"get selector"
			with:	('set', nameString, ':') asSymbol]].	"set selector"

	(categoryString = 'scripts') ifTrue:
		[^ self tileScriptCommands].
	self hasCostumeThatIsAWorld ifTrue: [^ self worldTilePhrasesSpecsForCategory: aCategory].
	aList _ ScriptingSystem categoryElementsFor: categoryString.
	aList ifNil: [self error: 'oops, missing category info for ', categoryString].
	aList _ self usablePhraseSpecsIn: aList.

	^ aList collect: [:aPair | self phraseSpecFor: aPair]

