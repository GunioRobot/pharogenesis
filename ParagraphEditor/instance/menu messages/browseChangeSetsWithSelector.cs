browseChangeSetsWithSelector
	"Determine which, if any, change sets have at least one change for the selected selector, independent of class"

	| aSelector |
	self lineSelectAndEmptyCheck: [^ self].
	(aSelector _ self selectedSelector) == nil ifTrue: [^ view flash].
	self terminateAndInitializeAround: [ChangeSorter browseChangeSetsWithSelector: aSelector]