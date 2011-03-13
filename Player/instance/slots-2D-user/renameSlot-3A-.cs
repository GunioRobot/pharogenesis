renameSlot: oldSlotName
	| reply newSlotName |
	reply _   FillInTheBlank request: 'New name for "', oldSlotName, '":' initialAnswer: oldSlotName.
 	reply size == 0 ifTrue: [^ self].
	newSlotName _ ScriptingSystem acceptableSlotNameFrom: reply forSlotCurrentlyNamed:  oldSlotName asSlotNameIn: self world: self costume currentWorld.
	self renameSlot: oldSlotName newSlotName: newSlotName