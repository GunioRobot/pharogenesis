sendersOfSelectedKey
	"Create a browser on all senders of the selected key"
	| aKey |
	self selectionIndex = 0
		ifTrue: [^ self changed: #flash].
	((aKey := keyArray at: selectionIndex  - self numberOfFixedFields) isKindOf: Symbol)
		ifFalse: [^ self changed: #flash].
	SystemNavigation default browseAllCallsOn: aKey