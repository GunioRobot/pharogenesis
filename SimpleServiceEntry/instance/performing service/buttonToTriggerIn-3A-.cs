buttonToTriggerIn: aFileList
	"Answer a button that will trigger the receiver service in a file list"

	| aButton |
	aButton _  PluggableButtonMorph
					on: self
					getState: nil
					action: #performServiceFor:.
	aButton 
		arguments: { aFileList }.

	aButton
		color: Color transparent;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		useRoundedCorners;
		label: self buttonLabel;
		askBeforeChanging: true;
		onColor: Color transparent offColor: Color transparent.
		aButton setBalloonText: self description.

		Preferences alternativeWindowLook
			ifTrue:
				[aButton borderWidth: 2; borderColor: #raised].
	^ aButton