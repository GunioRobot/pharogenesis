emitStorePop: stack on: aStream
	"N, toBraceStack:, pop, pop elemN, ..., pop elem1"

	nElementsNode emitForValue: stack on: aStream.
	toBraceStackNode emit: stack args: 1 on: aStream.
	stack push: elements size.
	aStream nextPut: Pop. stack pop: 1.
	elements reverseDo: [:element | element emitStorePop: stack on: aStream]