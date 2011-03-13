listForPattern: pat
	"Make the list be those file names which match the pattern."
	| newList thisName allFiles sizeStr specList maxiPad |
	specList _ directory directoryContents.
	sortMode == #size
		ifTrue: [maxiPad _ (specList inject: 0 into:
						[:mx :spec | mx max: (spec at: 5)])
							asStringWithCommas size - 1].
	newList _ sortMode == #name
		ifTrue: [(SortedCollection new: 30) sortBlock: [:x :y | x <= y]]
		ifFalse: [(SortedCollection new: 30) sortBlock: [:x :y | x >= y]].
	allFiles _ pat = '*'.
	specList do:
		[:spec | "<name><creationTime><modificationTime><dirFlag><fileSize>"
		thisName _ (spec at: 4)
			ifTrue: [spec first , self folderString]
			ifFalse: [spec first].
		(allFiles or: [pat match: thisName]) ifTrue:
			[sortMode == #date
				ifTrue: [thisName _ '(' ,
						((Date fromDays: (spec at: 3) // 86400)
							printFormat: #(3 2 1 $. 1 1 2)) , ' ' ,
						(String streamContents: [:s |
							(Time fromSeconds: (spec at: 3) \\ 86400)
								print24: true on: s])
						, ') ' , thisName].
			sortMode == #size
				ifTrue: [sizeStr _ (spec at: 5) asStringWithCommas.
						thisName _ '(' ,
							((sizeStr size to: maxiPad) collect: [:i | $ ]) ,
							sizeStr
						, ') ' , thisName].
			newList add: thisName]].
	^ newList