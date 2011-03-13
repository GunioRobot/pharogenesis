optionalButtonRow
	"Answer a button pane affording the user one-touch access to certain functions; the pane is given the formal name 'buttonPane' by which it can be retrieved by code wishing to send messages to widgets residing on the pane"

	| buttons aLabel |
	buttons := OrderedCollection new.
	self optionalButtonPairs do: [:tuple |
		aLabel := Preferences abbreviatedBrowserButtons 
			ifTrue: [self abbreviatedWordingFor: tuple second].
		buttons add: ((PluggableButtonMorph
			on: self
			getState: nil
			action: tuple second)
			hResizing: #spaceFill;
			vResizing: #spaceFill;
			askBeforeChanging: (#(proceed restart send doStep stepIntoBlock fullStack where) includes: tuple second);
			label: (aLabel ifNil: [tuple first asString]);
			setBalloonText: (tuple size > 2 ifTrue: [tuple third]))].
	^(UITheme builder newRow:  buttons)
		cellInset: 2