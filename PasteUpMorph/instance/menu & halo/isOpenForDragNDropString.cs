isOpenForDragNDropString
	^ self dragNDropEnabled
		ifTrue:
			['stop being open to drag & drop']
		ifFalse:
			['start being open to drag & drop']
