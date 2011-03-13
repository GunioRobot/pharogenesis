slotNamesAndTypesForViewerBank: aBank
	^ (self standardSlotsForBank: aBank), (self personalSlotNamesAndTypesForBank: aBank), (self costumeSlotNamesAndTypesForBank: aBank)