infoFor: aSlotName
	"The user made a gesture asking for info/menu relating"

	| aString aMenu reply |
	aString _ aSlotName asString, ' (', (self typeForSlot: aSlotName asSymbol), ')'.
	(self slotInfo includesKey: aSlotName asSymbol)
		ifTrue:  "User slot"
			[aMenu _ SelectionMenu labelList: 
				#('change data type'
					'remove this instance variable'
					'rename this instance variable')
			selections: #(chooseSlotType removeSlot renameSlot).
			reply _ aMenu startUpWithCaption: aString.
			reply == nil ifTrue: [^ self].
			reply == #chooseSlotType ifTrue: [^ self chooseSlotTypeFor: aSlotName asSymbol].
			reply == #removeSlot ifTrue: [^ self removeSlotNamed:  aSlotName asSymbol].
			reply == #renameSlot ifTrue: [^ self renameSlot: aSlotName asSymbol]].

	aString _ aString, (String with: Character cr), (ScriptingSystem helpStringFor: aSlotName).
	self inform: aString