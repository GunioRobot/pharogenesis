parseListContents: listContents
	| sections vers strm line fileNames |
	"Parse the contents of updates.list into {{vers. {fileNames*}}*}, and return it."

	sections _ OrderedCollection new.
	fileNames _ OrderedCollection new: 1000.
	vers _ nil.
	strm _ ReadStream on: listContents.
	[strm atEnd] whileFalse:
		[line _ strm upTo: Character cr.
		line size > 0 ifTrue:
			[line first = $#
				ifTrue: [vers ifNotNil: [sections addLast: {vers. fileNames asArray}].
						"Start a new section"
						vers _ line allButFirst.
						fileNames resetTo: 1]
				ifFalse: [line first = $* ifFalse: [fileNames addLast: line]]]].
	vers ifNotNil: [sections addLast: {vers. fileNames asArray}].
	^ sections asArray
" TEST:
 | list |
list _ Utilities parseListContents: (FileStream oldFileNamed: 'updates.list') contentsOfEntireFile.
list = (Utilities parseListContents: (String streamContents: [:s | Utilities writeList: list toStream: s]))
	ifFalse: [self error: 'test failed']
	ifTrue: [self inform: 'test OK']
"