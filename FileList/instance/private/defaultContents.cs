defaultContents

	list == nil ifTrue: [^ String new].
	^ String streamContents:
		[:s | s nextPutAll: 'NO FILE SELECTED'; cr.
		s nextPutAll: '  -- Folder Summary --'; cr.
		list do: [:item | s nextPutAll: item; cr]]