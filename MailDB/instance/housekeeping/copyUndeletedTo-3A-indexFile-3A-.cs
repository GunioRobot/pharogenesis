copyUndeletedTo: newMsgFile indexFile: newIndexFile
	"Copy all the undeleted messages in my current message file into the new message file, recording their locations in the new index file. Answer an array containing with the number of messages and the number of bytes recovered."
	"Note: To minimize disk seeks, messages are buffered and written in large batches. You may wish to tune the amount of buffering if you have a particular shortage or abundance of physical memory. bufferLimit is the approximate number of bytes of messages that will be accumulated before writing the buffered messages to disk."

	| bufferLimit msgBuffer bufferSize deletedCount deletedBytes |
	Smalltalk garbageCollect.
	bufferLimit _ Smalltalk bytesLeft // 2.	"use half of the available memory"
	msgBuffer _ OrderedCollection new: 1000.
	bufferSize _ 0.
	deletedCount _ deletedBytes _ 0.
	newMsgFile beginAppend.
	messageFile messagesDo:
		[: deleted : msgID : msgText |
		 (deleted)
			ifTrue:
				[deletedCount _ deletedCount + 1.
				 deletedBytes _ deletedBytes + msgText size]
			ifFalse:
				[msgBuffer addLast: (Array with: msgID with: msgText).
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

	"return statistics"
	^Array with: deletedCount with: deletedBytes