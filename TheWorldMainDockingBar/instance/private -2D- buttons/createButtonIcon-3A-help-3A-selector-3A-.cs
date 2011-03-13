createButtonIcon: aFormOrMorph help: helpStringOrNil selector: selector 
	"Private - Creates a button to fire an action from a docking bar"
	| button icon |
	button := RectangleMorph new.
	button extent: aFormOrMorph extent + 2.
	button borderWidth: 0.
	button color: self offColor.
	helpStringOrNil isNil

		ifFalse: [button setBalloonText: helpStringOrNil translated].
	""
	icon := aFormOrMorph isMorph
				ifTrue: [aFormOrMorph]
				ifFalse: [SketchMorph withForm: aFormOrMorph].
	button addMorphCentered: icon.
	""
	button
		on: #mouseDown
		send: #perform:event:for:
		to: self
		withValue: selector.
	button
		on: #mouseEnter
		send: #colorOnEvent:for:
		to: self.
	button
		on: #mouseLeave
		send: #colorOffEvent:for:
		to: self.
	""
	^ button