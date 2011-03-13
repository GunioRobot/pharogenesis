fileNameFormattedFrom: entry sizePad: sizePad
	"entry is a 5-element array of the form:
		(name creationTime modificationTime dirFlag fileSize)"
	| sizeStr nameStr dateStr |
	nameStr _ (entry at: 4)
		ifTrue: [entry first , self folderString]
		ifFalse: [entry first].
	dateStr _ ((Date fromDays: (entry at: 3) // 86400)
					printFormat: #(3 2 1 $. 1 1 2)) , ' ' ,
				(String streamContents: [:s |
					(Time fromSeconds: (entry at: 3) \\ 86400)
						print24: true on: s]).
	sizeStr _ (entry at: 5) asStringWithCommas.
	sortMode = #name ifTrue:
		[^ nameStr , '    (' , dateStr , ' ' , sizeStr , ')'].
	sortMode = #date ifTrue:
		[^ '(' , dateStr , ' ' , sizeStr , ') ' , nameStr].
	sortMode = #size ifTrue:
		[^ '(' , ((sizeStr size to: sizePad) collect: [:i | $ ]) , sizeStr , ' ' , dateStr , ') ' , nameStr].
