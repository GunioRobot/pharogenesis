existingPaneColor
	"Answer the existing pane color for the window, obtaining it from the first paneMorph if any, and fall back on using the second stripe color if necessary."

	| aColor |
	Preferences alternativeWindowLook 
		ifTrue: 
			[aColor := self valueOfProperty: #paneColor.
			aColor 
				ifNil: [self setProperty: #paneColor toValue: (aColor := self paneColor)].
			^aColor].
	paneMorphs isEmptyOrNil 
		ifFalse: 
			[((aColor := paneMorphs first color) isColor) ifTrue: [^aColor]].
	^stripes ifNotNil: [stripes second color] ifNil: [Color blue lighter]