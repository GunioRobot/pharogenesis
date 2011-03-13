getList
	"Answer the list to be displayed.  Caches the returned list in the 'list' ivar"
	getListSelector == nil ifTrue: [^ #()].
	list := model perform: getListSelector.
	list == nil ifTrue: [^ #()].
	list := list collect: [ :item | item asStringOrText ].
	^ list