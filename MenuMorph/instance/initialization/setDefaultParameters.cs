setDefaultParameters
	"change the receiver's appareance parameters"

	| colorFromMenu worldColor menuColor |
	
	colorFromMenu := Preferences menuColorFromWorld
									and: [Display depth > 4]
									and: [(worldColor := self currentWorld color) isColor].

	menuColor := colorFromMenu
						ifTrue: [worldColor luminance > 0.7
										ifTrue: [worldColor mixed: 0.85 with: Color black]
										ifFalse: [worldColor mixed: 0.4 with: Color white]]
						ifFalse: [Preferences menuColor].

	self color: menuColor.
	self borderWidth: Preferences menuBorderWidth.

	Preferences menuAppearance3d ifTrue: [
		self borderStyle: BorderStyle thinGray.
		self
			addDropShadow;
			shadowColor: (TranslucentColor r: 0.0 g: 0.0 b: 0.0 alpha: 0.666);
			shadowOffset: 1 @ 1
	]
	ifFalse: [
		| menuBorderColor |
		menuBorderColor := colorFromMenu
										ifTrue: [worldColor muchDarker]
										ifFalse: [Preferences menuBorderColor].
		self borderColor: menuBorderColor.
	].


	self layoutInset: 3.
