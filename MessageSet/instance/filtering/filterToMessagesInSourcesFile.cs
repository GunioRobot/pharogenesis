filterToMessagesInSourcesFile
	"Filter down only to messages whose source code resides in the .sources file."

	| cm |
	self filterFrom: [:aClass :aSelector |
		(aClass notNil and: [aSelector notNil]) and:
			[(self class isPseudoSelector: aSelector) not and:
				[(cm _ aClass compiledMethodAt: aSelector ifAbsent: [nil]) notNil and:
					[cm fileIndex == 1]]]]