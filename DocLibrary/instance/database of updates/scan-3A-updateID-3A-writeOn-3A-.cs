scan: updateStream updateID: updateID writeOn: strm
	"Scan this update file and remember the update numbers of the methods."

	| changeList ee semi |
	updateStream reset; readOnly.
	Cursor read showWhile:
		[changeList _ ChangeList new
			scanFile: updateStream from: 0 to: updateStream size].
	changeList list do: [:entry |
		ee _ nil.
		(entry beginsWith: 'method: ') ifTrue: [
			(semi _ entry indexOf: $;) = 0 
				ifTrue: [semi _ entry size]
				ifFalse: [semi _ semi-1].
			ee _ entry copyFrom: 9 to: semi].
		(entry beginsWith: 'class comment for ') ifTrue: [
			(semi _ entry indexOf: $;) = 0 
				ifTrue: [semi _ entry size]
				ifFalse: [semi _ semi-1].
			ee _ entry copyFrom: 19 to: semi].	"comment for whole class"
		ee ifNotNil: [
			Transcript show: ee; cr.
			strm cr; nextPutAll: ee surroundedBySingleQuotes; space;
				nextPutAll: updateID asString].
		].