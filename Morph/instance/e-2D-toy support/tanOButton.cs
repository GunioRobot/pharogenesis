tanOButton
	"Answer a button with the old O on a tan background, targeted to self"

	| aButton |
	aButton _ IconicButton new labelGraphic: (ScriptingSystem formAtKey: #TanO).
	aButton color: Color transparent; borderWidth: 0; shedSelvedge; actWhen: #buttonUp.
	aButton target: self.
	^ aButton