filterToMessagesInChangesFile
	"Filter down only to messages whose source code risides in the Changes file.  This allows one to ignore long-standing methods that live in the .sources file."

	| cm |
	self filterFrom:
		[:aClass :aSelector |
			aClass notNil and: [aSelector notNil and:
				[(self class isPseudoSelector: aSelector) not and:
					[(cm _ aClass compiledMethodAt: aSelector ifAbsent: [nil]) notNil and:
					[cm fileIndex ~~ 1]]]]]