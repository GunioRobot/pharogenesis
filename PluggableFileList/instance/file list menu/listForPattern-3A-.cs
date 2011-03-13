listForPattern: pat
	"Make the list be those file names which match the pattern."
	| entries sizePad newList allFiles |
	entries _ directory entries select: fileFilterBlock.
	sizePad _ (entries inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.

	newList _ (SortedCollection new: 30) sortBlock: self sortBlock.

	allFiles _ pat = '*'.
	entries do:
		[:entry | "<dirflag><name><creationTime><modificationTime><fileSize>"
		(allFiles or: [entry isDirectory or: [pat match: entry first]]) ifTrue:
			[newList add: entry]].

	newList _ newList collect: [ :e | self fileNameFormattedFrom: e sizePad: sizePad ].

	volList size = 1 ifTrue:
		["Include known servers along with other desktop volumes" 
		^ newList asArray ,
		(ServerDirectory serverNames collect: [:n | '^' , n , self folderString])].
	newFiles _ OrderedCollection new.
	^ newList asArray.