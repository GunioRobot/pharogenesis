noteRenameOf: oldSlotName to: newSlotName inPlayer: aPlayer
	"Note that aPlayer has renamed a slot formerly known as oldSlotName to be newSlotName"

	self allScriptEditors do:
		[:anEditor | (anEditor hasScriptReferencing: oldSlotName ofPlayer: aPlayer) ifTrue: 
			[self flag: #deferred.   "Now what?  Just implement the following?!"
			anEditor replaceReferencesToSlot: oldSlotName inPlayer: aPlayer with: newSlotName]]