dropDestinationDirectory: dest event: evt 
	"Answer a FileDirectory representing the drop destination in the volume list morph dest"
	| index dir delim path |
	index _ volList indexOf: (dest itemFromPoint: evt position) contents.
	index = 1
		ifTrue: [dir _ FileDirectory on: '']
		ifFalse: [delim _ directory pathNameDelimiter.
			path _ String
						streamContents: [:str | 
							2
								to: index
								do: [:d | 
									str nextPutAll: (volList at: d) withBlanksTrimmed.
									d < index
										ifTrue: [str nextPut: delim]].
							nil].
			dir _ directory on: path].
	^ dir