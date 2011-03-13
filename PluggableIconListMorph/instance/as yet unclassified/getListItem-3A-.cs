getListItem: index
	"get the index-th item in the displayed list"

	getListElementSelector ifNotNil: [
		^self itemMorphFor: (model perform: getListElementSelector with: index)].
	(list notNil and: [list size >= index]) ifTrue: [ ^list at: index ].
	^self getList at: index