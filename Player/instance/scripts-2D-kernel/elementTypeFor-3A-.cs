elementTypeFor: aStringOrSymbol
	| aSymbol |
	aSymbol _ aStringOrSymbol asSymbol.
	(ScriptingSystem typeForSystemSlotNamed: aSymbol) ifNotNil: [^ #systemSlot].
	(ScriptingSystem scriptInfoFor: aSymbol) ifNotNil: [^ #systemScript].
	(self slotInfo includesKey: aSymbol) ifTrue: [^ #userSlot].
	^ #userScript