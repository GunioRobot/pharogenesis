pinkXButton
	"Answer a button with the old X on a pink background, targeted to self"

	| aButton |
	aButton _ IconicButton new labelGraphic: (ScriptingSystem formAtKey: #PinkX).
	aButton color: Color transparent; borderWidth: 0; shedSelvedge; actWhen: #buttonUp.
	aButton target: self.
	^ aButton