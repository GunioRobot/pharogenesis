acceptDroppingMorph: transferMorph event: evt inMorph: dstListMorph 
	"Accept messageIDs from the tocEntryList.  Move the indicated message to the destination category."

	| srcType moveID destCategory savedCurrentMsgID |
	srcType _ transferMorph dragTransferType.
	srcType == #tocEntryList ifFalse: [^false].

	"Get the message ID and the destination category"
	moveID _ transferMorph passenger initialIntegerOrNil.
	destCategory _ dstListMorph potentialDropItem.
	[moveID isKindOf: Integer] assert.
	[self categoryList includes: destCategory] assert.

	"Don't do anything if the message was dropped into some particular categories"
	"(destCategory = self category) ifTrue: [^false]."	"the current category"
	(destCategory = '.all.') ifTrue: [^false].				"the computed category .all."
	(destCategory = '.unclassified.') ifTrue: [^false ].  "another computed category"

	"Quickly remove the message from those displayed using removeMessage:.  And a bit of fiddling to ensure we display the original message or something similar"
	savedCurrentMsgID _ currentMsgID.
	"self removeMessage: moveID."   "this is problematic, especially with moves between separate Celeste windows.  The behavior should probably be that it gets removed from whatever category the source Celeste specified"
	mailDB file: moveID inCategory: destCategory.
Transcript show: 'moveID: ', moveID printString, '  category: ', destCategory printString; cr.
	savedCurrentMsgID = moveID ifFalse: [self displayMessage: savedCurrentMsgID].
	self updateTOC.  "potentially slow, but at least it's safe"
	^true