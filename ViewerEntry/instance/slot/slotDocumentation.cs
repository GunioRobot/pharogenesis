slotDocumentation
	"Provide some text to fill the detail pane for a slot in a Viewer"
	| aSlotName info |
	aSlotName _ self slotName.
	(self entryType == #systemSlot) ifTrue:
			[^ ScriptingSystem helpStringFor: aSlotName].
	(self entryType == #userSlot) ifTrue:
		[info _ ((info _ self playerBearingCode slotInfo) includesKey: aSlotName)
			ifTrue:
				[info at: aSlotName]
			ifFalse:
				[nil].
		^ info
			ifNil:
				['um... here would come documentation for ', aSlotName]
			ifNotNil:
				[info documentation]].
	^ nil