renameSlot: oldSlotName
	| reply newSlotName |
	reply _   FillInTheBlank request: 'New name for "', oldSlotName, '":' initialAnswer: oldSlotName.
 	reply size == 0 ifTrue: [^ self].
	reply first isUppercase ifTrue: [^ self inform: 'Must start with lower case letter.'].
	(Scanner isLiteralSymbol: reply) ifFalse: [^ self inform: 'Bad script name, please try again'].
	
	((newSlotName _ reply asSymbol) == oldSlotName) ifTrue: [^ self].
	(self class slotInfo includesKey: newSlotName) ifTrue: [^ self inform: 'Sorry, that name is already in use'].
	(ScriptingSystem isAcceptablePlayerSlotName: newSlotName)
		ifFalse:
			[^ self inform: 'Sorry, that name is reserved.'].
	self renameSlot: oldSlotName newSlotName: newSlotName