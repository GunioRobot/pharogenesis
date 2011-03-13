statusReplyReceivedString

	| statusTime |
	statusTime _ self valueOfProperty: #lastStatusReplyTime ifAbsent: [^'none'].
	^(self dateAndTimeStringFrom: statusTime),' accepts:
', (self valueOfProperty: #lastStatusReply) asArray printString