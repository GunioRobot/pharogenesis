metaClassIndicated: trueOrFalse
	metaClassIndicated == trueOrFalse ifTrue: [^ self].
	(metaClassIndicated _ trueOrFalse)
		ifTrue: [instButton color: paneColor.
				classButton color: paneColor darker]
		ifFalse: [instButton color: paneColor darker.
				classButton color: paneColor].
	classPane selection == nil ifFalse:
		[categoryPane list: self selectedClassOrMetaClass organization categories]