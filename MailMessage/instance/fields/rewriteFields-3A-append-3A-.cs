rewriteFields: aBlock append: appendBlock
	"Rewrite header fields. The body is not modified.
	Each field's key and value is reported to aBlock. The block's return value is the replacement for the entire header line. Nil means don't change the line, empty means delete it. After all fields are processed, evaluate appendBlock and append the result to the header."

	| old new result appendString |
	old _ ReadStream on: text.
	new _ WriteStream on: (String new: text size).
	self fieldsFrom: old do: [ :fName :fValue |
		result _ aBlock value: fName value: fValue.
		result ifNil: [new nextPutAll: fName, ': ', fValue; cr]
			ifNotNil: [result isEmpty
				ifFalse: [new nextPutAll: result.
					result last = Character cr ifFalse: [new cr]]]].
	appendString _ appendBlock value.
	appendString isEmptyOrNil ifFalse:
		[new nextPutAll: appendString.
		appendString last = Character cr ifFalse: [new cr]].
	new cr. "End of header"
	text _ new contents, old upToEnd.
	self cacheFieldsFrom: (ReadStream on: text) andDo: [:f :n | "Just chache it"]