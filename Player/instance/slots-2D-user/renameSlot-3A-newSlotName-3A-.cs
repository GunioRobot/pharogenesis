renameSlot: oldSlotName newSlotName: newSlotName
	self class renameSilentlyInstVar: oldSlotName to: newSlotName.
	self updateAllViewers.
	self flag: #deferred.
	"Any scripts that formerly sent oldSlotName should now send newSlotName"

	self inform: 
'Caution!  Any scripts that may reference this
instance variable by its old name may now be
broken -- you may need to fix them up manually.  
In some future release, we''ll automatically
fix those up, hopefully.'.

	self costume world presenter allExtantPlayers do:
		[:aPlayer | (aPlayer hasScriptReferencing: oldSlotName ofPlayer: self)
			ifTrue:
				[^ aPlayer noteRenameOf: oldSlotName to: newSlotName inPlayer: self]].
	^ true