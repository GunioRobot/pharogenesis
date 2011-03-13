chooseFilterForCurrentMessage
	"automatically choose a filter to move the selected message.  Returns nil if there isn't a message selected, or if there isn't exactly 1 matching filter"
	| matchingFilters |
	currentMsgID ifNil: [ ^nil ].
	matchingFilters := self filtersFor: currentMsgID from: CustomFilters keys.
	matchingFilters size = 1
		ifTrue: [ ^matchingFilters someElement ]
		ifFalse: [ ^nil ]