setCostumeSlot: setterSelector toValue: aValue
	| aCostume |
	(aCostume _ self costumeRespondingTo: setterSelector) ifNotNil:
		[aCostume perform: setterSelector with: aValue]