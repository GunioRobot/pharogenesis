isOpenForDragNDropString
	"Answer the string to be shown in a menu to represent the open-to-drag-n-drop status"

	^ self dragNDropEnabled
		ifTrue:
			['<on>open to drag & drop']
		ifFalse:
			['<off>open to drag & drop']
