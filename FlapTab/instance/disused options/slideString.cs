slideString

	^ slidesOtherObjects
		ifTrue:
			['cease slide behavior']
		ifFalse:
			['start slide behavior']