defaultContents
	contents _ list == nil
		ifTrue: [String new]
		ifFalse: [String streamContents:
					[:s | s nextPutAll: 'NO FILE SELECTED'; cr.
					s nextPutAll: '  -- Folder Summary --'; cr.
					list do: [:item | s nextPutAll: item; cr]]].
	brevityState _ #FileList.
	^ contents