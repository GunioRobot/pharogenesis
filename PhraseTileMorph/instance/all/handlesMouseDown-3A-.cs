handlesMouseDown: evt
	| editor |
	^ (editor _ self topEditor)
		ifNil:
			[false]
		ifNotNil:
			[editor openToDragNDrop]