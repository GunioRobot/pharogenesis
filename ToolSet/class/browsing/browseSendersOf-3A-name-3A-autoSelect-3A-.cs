browseSendersOf: aSymbol name: titleString autoSelect: autoSelectString
	"Open a senders browser"
	self default ifNil:[^self inform: 'Cannot open SendersBrowser'].
	^self default browseSendersOf: aSymbol name: titleString autoSelect: autoSelectString