listForPattern: pat
	"Make the list be those file names which match the pattern."
	| entries sizePad newList allFiles sortBlock |
	entries _ directory entries select: fileFilterBlock.
	sizePad _ (entries inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.

	"create block to decide what order to display the entries"
	sortBlock _ [ :x :y |
			(x isDirectory = y isDirectory) 
				ifTrue: [  
					"sort by user-specified criterion"
					sortMode = #name 
						ifTrue: [(x name compare: y name) <= 2]
						ifFalse: [ sortMode = #date
							ifTrue: [ x modificationTime = y modificationTime
									ifTrue: [ (x name compare: y name) <= 2 ]
									ifFalse: [ x modificationTime > y modificationTime ] ]
							ifFalse: [ "size"
								x fileSize = y fileSize 
									ifTrue: [ (x name compare: y name) <= 2 ]
									ifFalse: [ x fileSize > y fileSize ] ] ] ]
				ifFalse: [
					"directories always precede files"
					x isDirectory ] ].

	newList _ (SortedCollection new: 30) sortBlock: sortBlock.

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