getList
	"fetch and answer the lists to be displayed"
	getListSelector == nil ifTrue: [^ #()].
	list _ model perform: getListSelector.
	list == nil ifTrue: [^ #()].
	list _ list collect: [ :column | column collect: [ :item | item asStringOrText ] ].
	^ list