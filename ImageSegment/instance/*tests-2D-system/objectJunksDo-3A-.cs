objectJunksDo: aBlock
	| index header type fieldStartIndex fieldCount fields |
	state == #activeCopy ifFalse:[self errorWrongState].
	index := 2. 	"skip version word, first object"
	"go past extra header words"
	type := (segment at: index) bitAnd: 3.
	type = 1 ifTrue: [ index := index + 1 ].
	type = 0 ifTrue: [ index := index + 2 ].
	[ index > segment size ] whileFalse: [
		header := segment at: index.
		fieldStartIndex := index + 1.			
		fieldCount := self numberOfFieldsOf: index.
		fields := segment copyFrom: fieldStartIndex to: fieldStartIndex + fieldCount - 1.
		aBlock value: (self classNameAt: index) value: header value: fields.
		index := self objectAfter: index.
		(fieldStartIndex + fieldCount - 1 < index) ifFalse: [ self error: 'should not happen' ].
	]