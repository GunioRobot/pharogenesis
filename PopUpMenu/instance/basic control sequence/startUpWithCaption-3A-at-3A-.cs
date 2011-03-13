startUpWithCaption: captionOrNil at: location
	"Display the menu, with caption if supplied. Wait for the mouse button to go down,
	then track the selection as long as the button is pressed. When the button is released, 
	answer the index of the current selection, or zero if the mouse is not released over 
	any menu item. Location specifies the desired topLeft of the menu body rectangle."

	| maxHeight |
	maxHeight _ Display height*3//4.
	self frameHeight > maxHeight ifTrue:
		[^ self
			startUpSegmented: maxHeight
			withCaption: captionOrNil
			at: location].

	Smalltalk isMorphic
		ifTrue:
			[selection _ Cursor normal showWhile:
				[(MVCMenuMorph from: self title: captionOrNil) 
					invokeAt: location 
					in: (Display morphicWorldAt: location)].
			^ selection].

	frame ifNil: [self computeForm].
	Cursor normal showWhile:
		[self
			displayAt: location
			withCaption: captionOrNil
			during: [self controlActivity]].
	^ selection