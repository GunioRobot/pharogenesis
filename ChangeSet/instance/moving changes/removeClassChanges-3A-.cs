removeClassChanges: class
	"Remove all memory of changes associated with this class"
	| cname |
	(class isString)
		ifTrue: [ cname _ class ]
		ifFalse: [ cname _ class name ].

	changeRecords removeKey: cname ifAbsent: [].
	self noteClassForgotten: cname.