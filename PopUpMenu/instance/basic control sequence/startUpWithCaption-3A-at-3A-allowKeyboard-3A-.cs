startUpWithCaption: captionOrNil at: location allowKeyboard: aBoolean
	"Display the menu, with caption if supplied. Wait for the mouse button to go down, then track the selection as long as the button is pressed. When the button is released,
	Answer the index of the current selection, or zero if the mouse is not released over  any menu item. Location specifies the desired topLeft of the menu body rectangle. The final argument indicates whether the menu should seize the keyboard focus in order to allow the user to navigate it via the keyboard."

	| maxHeight |
	(ProvideAnswerNotification signal: captionOrNil) ifNotNilDo:
		[:answer | ^ selection _ answer ifTrue: [1] ifFalse: [2]].
		 
	maxHeight _ Display height*3//4.
	self frameHeight > maxHeight ifTrue:
		[^ self
			startUpSegmented: maxHeight
			withCaption: captionOrNil
			at: location
			allowKeyboard: aBoolean].

	Smalltalk isMorphic
		ifTrue:[
			selection _ Cursor normal showWhile:
				[(MVCMenuMorph from: self title: captionOrNil) 
					invokeAt: location 
					in: ActiveWorld
					allowKeyboard: aBoolean].
			^ selection].

	frame ifNil: [self computeForm].
	Cursor normal showWhile:
		[self
			displayAt: location
			withCaption: captionOrNil
			during: [self controlActivity]].
	^ selection