getList
	"Answer the list to be displayed.  Caches the returned list in the 'list' ivar"
	getListSelector == nil ifTrue: [^ #()].
	list _ model perform: getListSelector.
	list == nil ifTrue: [^ #()].
	list _ list collect: [ :item | item asStringOrText ].
	^ list