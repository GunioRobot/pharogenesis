computeTOCStringAsColumns
	"Answer a string for the table of contents."
	"IndexFileEntry allInstancesDo: [: e | e flushTOCCache]"
	| fromFieldSize array attachFlag |
	fromFieldSize _ 18.
	attachFlag _ Celeste showAttachmentsFlag
		ifTrue: [self getMessage body isMultipart]
		ifFalse: [false].
	array _ Array new: 5.
	array at: 1 put: self dateString.
	array
		at: 2
		put: (self fromStringLimit: fromFieldSize).
	array at: 3 put: subject.
	array at: 4 put: self textLength asStringWithCommas.
	array at: 5 put: attachFlag.
	^ array