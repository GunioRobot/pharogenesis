costumeSlotNamesAndTypesForBank: aBank
	"Return an array of slot names and slot info to be added by the receiver's various costumes for use in a viewer on the receiver"

	| names aList |
	names _ OrderedCollection new.
	aList _ OrderedCollection new.
	self costumesDo:
		[:aCostume |
			(aCostume slotNamesAndTypesForBank: aBank) do:
				[:aPair | (names includes: aPair first)
					ifFalse:
						[aList add: aPair.
						names add: aPair first]]].
	^ aList