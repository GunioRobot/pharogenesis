getOnly: numberOfBytes ofProjectContents: aString 
	"private - get numberOfBytes of the project contents"
	| url answer contents args |
	self flag: #todo.
	"use an LRUCache"
	url := self urlFromServer: self server directories: {'programmatic'. aString}.
	""
	args := numberOfBytes isNil
				ifFalse: ['numberOfBytes=' , numberOfBytes asString].
	""
	Cursor read
		showWhile: [""
			answer := HTTPSocket httpGetDocument: url args: args.
			contents := answer contents].""
	(contents beginsWith: '--OK--')
		ifFalse: [^ nil].
	""
	^ contents allButFirst: 6