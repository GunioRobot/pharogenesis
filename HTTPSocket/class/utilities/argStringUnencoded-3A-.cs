argStringUnencoded: args
	"Return the args in a long string, as encoded in a url"

	| argsString first |
	args class == String ifTrue: ["sent in as a string, not a dictionary"
		^ (args first = $? ifTrue: [''] ifFalse: ['?']), args].
	argsString _ WriteStream on: String new.
	argsString nextPut: $?.
	first _ true.
	args associationsDo: [ :assoc |
		assoc value do: [ :value |
			first ifTrue: [ first _ false ] ifFalse: [ argsString nextPut: $& ].
			argsString nextPutAll: assoc key.
			argsString nextPut: $=.
			argsString nextPutAll: value. ] ].
	^ argsString contents
