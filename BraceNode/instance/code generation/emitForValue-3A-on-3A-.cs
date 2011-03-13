emitForValue: stack on: aStream
	"elem1, ..., elemN, collectionClass, N, fromBraceStack:"

	| element |
	elements do: [:element | element emitForValue: stack on: aStream].
	collClassNode emitForValue: stack on: aStream.
	nElementsNode emitForValue: stack on: aStream.
	fromBraceStackNode emit: stack args: 1 on: aStream.
	stack pop: elements size