removeSlotNamed: aSlotName
	(self okayToRemoveSlotNamed: aSlotName) ifFalse:
		[^ self inform: 'Sorry, ', aSlotName, ' is in
use in a script.'].
	self inform: 
'Caution!  Any scripts that may reference
this instance variable may now be broken.
You may need to fix them up manually.  
In some future release, we''ll automatically
fix those up, hopefully.'.

	self class removeInstVarName: aSlotName asString.

	self updateAllViewers
