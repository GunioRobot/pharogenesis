copyUndeletedTo: newMsgFile indexFile: newIndexFile
	"Copy all the undeleted messages in my current message file into the new message file, recording their locations in the new index file.  Also eliminates duplicate messageIDs.  Answer an array containing with the number of messages and the number of bytes recovered, as well as the number of messages still remaining."

	| bufferLimit msgBuffer bufferSize deletedCount deletedBytes msgIDlist keptCount duplicateMsgCount |

	msgIDlist _ Set new: 10000.	"Record of the msgIDs we have already processed"
	deletedCount _ deletedBytes _ 0.
	keptCount _ 0.
	duplicateMsgCount _ 0.

	"Note: To reduce disk seeks, messages are buffered and written in large batches.  You may wish to tune the amount of buffering if you have a particular shortage or abundance of physical memory.  bufferLimit is the approximate number of bytes of messages that will be accumulated before writing the buffered messages to disk."
	Smalltalk garbageCollect.
	msgBuffer _ OrderedCollection new: 1000.
	bufferLimit _ (Smalltalk primBytesLeft // 2) min: 2000000.
	bufferSize _ 0.

	newMsgFile beginAppend.
	messageFile messagesDo:
		[: deleted : msgID : msgText |
		 (deleted)
			ifTrue:
				[deletedCount _ deletedCount + 1.
				 deletedBytes _ deletedBytes + msgText size]
			ifFalse:
				[
				(msgIDlist includes: msgID) ifTrue: [	"We have a duplicate msgID"
					"We only renumber if we have previously salvaged"
					"and thus know all of the existing message IDs"
					(canRenumberMsgIDs = true)
						ifTrue: [msgID _ self nextUnusedID]
						ifFalse: [duplicateMsgCount _ duplicateMsgCount + 1]
					].
				msgIDlist add: msgID.

				msgBuffer addLast: (Array with: msgID with: msgText).
				keptCount _ keptCount + 1.
				 bufferSize _ bufferSize + msgText size.
				 (bufferSize >= bufferLimit) ifTrue:
					[self
						appendMessages: msgBuffer
						messageFile: newMsgFile
						indexFile: newIndexFile.
					 msgBuffer _ OrderedCollection new: 1000.
					 bufferSize _ 0]]].

	"flush remaining buffered messages"
	self
		appendMessages: msgBuffer
		messageFile: newMsgFile
		indexFile: newIndexFile.
	newMsgFile endAppend.

	(canRenumberMsgIDs = true) ifTrue: [
		canRenumberMsgIDs _ nil.	"We're now done with renumbering duplicate IDs"
		[duplicateMsgCount = 0] assert.
		].

	duplicateMsgCount > 0 ifTrue: [
		canRenumberMsgIDs _ true.		"Allow renumbering duplicate IDs next time around"
		lastIssuedMsgID _ nil.			"Ensure it is later initialized by nextUnusedID"
		self inform:
			'Warning:  ', duplicateMsgCount printString, ' duplicate msgIDs were found.', String cr,
			'Please use "salvage & compact" again to replace them with the correct unique IDs'.
		].

	"return statistics"
	^Array with: deletedCount with: deletedBytes with: keptCount