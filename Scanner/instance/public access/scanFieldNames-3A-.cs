scanFieldNames: stringOrArray
	"Answer an Array of Strings that are the identifiers in the input string, 
	stringOrArray. If passed an Array, just answer with that Array, i.e., 
	assume it has already been scanned."

	| strm |
	(stringOrArray isMemberOf: Array)
		ifTrue: [^stringOrArray].
	self scan: (ReadStream on: stringOrArray asString).
	strm _ WriteStream on: (Array new: 10).
	[tokenType = #doIt]
		whileFalse: 
			[tokenType = #word ifTrue: [strm nextPut: token].
			self scanToken].
	^strm contents

	"Scanner new scanFieldNames: 'abc  def ghi' ('abc' 'def' 'ghi' )"