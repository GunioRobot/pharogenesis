scanToNextMessageIn: aStream
	"Scan to the start of the next message in the given stream. Answer true if we find a message delimiter, false if we hit the end of the stream first. The stream is left positioned at the start of the next message delimiter (if there is one) or at the end of the stream."

	| msgStart |
	[true] whileTrue:
		[(aStream skipTo: $:) ifFalse: [^false].	"end of stream"
		 msgStart _ aStream position - 1.
		 ((MailDB readStringLineFrom: aStream) = ':::::::::::::') ifTrue:
			["looking good..."
			 MailDB skipRestOfLine: aStream.	"skip message number"
			 ((MailDB readStringLineFrom: aStream) = '::::::::::::::') ifTrue:
				["found a message!"
				 aStream position: msgStart. ^true]].
		 "false alarm, keep scanning"
		 aStream position: msgStart + 1].