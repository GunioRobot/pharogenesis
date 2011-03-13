iconFor: anEntry
	"Answer the icon to use for the directory entry."

	^anEntry isDirectory
		ifTrue: [MenuIcons smallOpenIcon]
		ifFalse: [(self isImageFile: anEntry name)
					ifTrue: [MenuIcons smallPaintIcon]
					ifFalse: [MenuIcons smallLeftFlushIcon]]