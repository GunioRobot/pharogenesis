removeSlotNamed: aSlotName
	(self okayToRemoveSlotNamed: aSlotName) ifFalse:
		[^ self inform: 'Sorry, ', aSlotName, ' is in
use in a script.'].

	self notYetImplemented