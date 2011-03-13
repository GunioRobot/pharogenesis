mouseDown: evt 
	"Make this TextMorph be the keyboard input focus, if it isn't  
	already, and repond to the text selection gesture.
	Changed to not take keyboard focus if an owner is a
	PluggableTextMorph that doesn't want focus."
	
	evt yellowButtonPressed
		ifTrue: ["First check for option (menu) click"
			^ self yellowButtonActivity: evt shiftPressed].
	self hasKeyboardFocus
		ifFalse: [(self ownerThatIsA: PluggableTextMorph)
					ifNil: [self takeKeyboardFocus]
					ifNotNilDo: [:ptm | ptm wantsKeyboardFocus ifTrue: [
							self takeKeyboardFocus]]].
	self handleInteraction: [editor mouseDown: evt]