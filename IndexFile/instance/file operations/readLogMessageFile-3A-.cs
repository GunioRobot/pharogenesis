readLogMessageFile: messageFile 
	| file msgID entry |
	file _ self logStream position: 0.
	[file atEnd]
		whileFalse: [(file peekFor: $r)
				ifTrue: 
					[MailDB readStringLineFrom: file.
					self privateRemove: (MailDB readIntegerLineFrom: file)]
				ifFalse: 
					[msgID _ MailDB readIntegerLineFrom: file.
					entry _ IndexFileEntry
								readFrom: file
								messageFile: messageFile
								msgID: msgID. self privateAt: msgID put: entry]]