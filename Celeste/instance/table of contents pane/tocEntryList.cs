tocEntryList
	"return a list of lists of strings: one list for each column in the TOC, one element in each list for each message in the current TOC"
	| lists messageColumns |
	self flag: #xxx.  "This is mostly used by drag-and-drop.  It would be better to have drag-and-drop transmit a message ID, than a TOC entry (or at least, for the drag-and-drop string to *include* a message id)"
	mailDB ifNil: [ ^(1 to: 6) collect: [ :ignored | #() ] ].
	lists := (1 to: 6) collect: [ :ignored | OrderedCollection new: currentMessages size ].

	currentMessages withIndexDo: [ :msgID :msgIndex |
		messageColumns := self tocColumnsForMessageID: msgID atIndex: msgIndex.
		messageColumns doWithIndex: [ :item :column |
			(lists at: column) add: item ] ].

	^lists