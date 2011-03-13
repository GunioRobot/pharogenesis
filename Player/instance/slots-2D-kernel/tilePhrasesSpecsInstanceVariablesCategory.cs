tilePhrasesSpecsInstanceVariablesCategory
	"Return an array of slot names and info for use in a viewer on the receiver to represent the instance-variables category"

	| nameString |
	^ self slotNames collect: [:aName | nameString _ aName asString capitalized.

		{#slot.				"NB: Brace construct here"
		aName asSymbol.					"name"
		'a user-defined instance variable'.	"balloon help"
		(self typeForSlot: aName asSymbol).	"type"
		#readWrite.							"r/w"
		#player.							"receiver of get  selector"
		('get', nameString) asSymbol.		"get selector"
		#player.							"receiver of set selector"
		('set', nameString, ':') asSymbol}]	"set selector"
