writeFileNamed: fileName
	| file noVoice |
	file _ FileStream newFileNamed: fileName.
	noVoice _ true.
	tape do:
		[:cell | cell value setHand: nil.
		cell value type = #startSound ifTrue: [noVoice _ false]].
	noVoice
		ifTrue: ["Simple format (reads fast) for no voice"
				tape do: [:cell | file store: cell key; space; store: cell value; cr].
				file close]
		ifFalse: ["Inclusion of voice events requires general object storage"
				file fileOutClass: nil andObject: tape].
	saved _ true.
	^ file name