elementTypeFor: aStringOrSymbol
	"Answer whether aStringOrSymbol is best characterized as a #systemSlot, #systemScript, #userSlot, or #userScript"

	| aSymbol |
	aSymbol _ aStringOrSymbol asSymbol.
	(ScriptingSystem typeForSystemSlotNamed: aSymbol) ifNotNil: [^ #systemSlot].
	(ScriptingSystem isSystemScriptName: aSymbol) ifTrue: [^ #systemScript].
	(self slotInfo includesKey: aSymbol) ifTrue: [^ #userSlot].
	^ #userScript