selfTest
	"This is purely for testing purposes.  It checks out various things to make sure that everything is well formed and looks as it should.  This can be a bit slow, but is very useful because it tests much of Celeste using every message in the mail database"

"NOTE: The mechanism used to generate IndexFileEntries has changed significantly over time, especially as MIME support was added and bugs were fixed.  That means that entries generated two years ago can sometimes be different from what would be generated with a current system.  Part of the selfTest compares the actual entry in the index file to what would be generated now.  The differences highlight three things:
	(1) Changes in convention between then and now (e.g. how we handle white space in a header continuation lines)
	(2) Results of bugs that were in the system when the entry was created and are now fixed
	(3) Functional result of changes made to Celeste
(1) and (3) are particularly helpful to use as part of testing enhancements to Celeste."

	| msgIDlist delCount goodCount msg dupid msgTextFromID indexEntry testEntry |

	msgIDlist _ Set new: 10000.
	delCount _ goodCount _ 0.
	dupid _ 0.

	messageFile messagesDo: [ :deleted :msgID :msgBody |

		deleted
			ifTrue: [ delCount _ delCount + 1 ]
			ifFalse: [ goodCount _ goodCount + 1 ].

		(msgIDlist includes: msgID)
			ifTrue: [dupid _ dupid + 1]
			ifFalse: [deleted ifFalse: [msgIDlist add: msgID]].

		"Try creating a formated version of the message from it's raw text"
		msg _ MailMessage from: msgBody.
		msg selfTest.
		
		deleted ifFalse: [
			"Check the indexing information for this message"

			"Check that the contents of this message is the same as what the index provides"
			msgTextFromID _ self getText: msgID.
			[msgTextFromID = msgBody] assert.

			"Check that the index entry is equivalent to what would be produced now"
			indexEntry _ indexFile at: msgID.
			testEntry _ IndexFileEntry message: msg location: indexEntry location messageFile: messageFile msgID: msgID.
			indexEntry selfTestEquals: testEntry. 
		]].

	Transcript cr; show: 'Dup:', dupid asString, '  del:', delCount asString, '  good:', goodCount asString; cr.

	"MailDB someInstance selfTest"