item: index
	"return the index-th item, using the 'listItems' cache"
	(index between: 1 and: listItems size)
		ifFalse: [ "there should have been an update, but there wasn't!"  ^self getListItem: index].
	(listItems at: index) ifNil: [ 
		listItems at: index put: (self getListItem: index). ].
	^listItems at: index