menuFlap
	| aFlap aFlapTab aHolder verticalHolder aMenu |
	aFlap _ PasteUpMorph newSticky color: Color transparent; extent: self currentWorld width @ 264; borderWidth: 0; padding: 0.

	aFlapTab _ FlapTab new referent: aFlap.
	aFlapTab color: Color brown lighter.
	aFlapTab assumeString: 'Menus' font: Preferences standardFlapFont orientation: #horizontal color: Color blue muchLighter.
	aFlapTab setToPopOutOnMouseOver: true.
	aFlapTab edgeToAdhereTo: #top; inboard: false.

	aFlapTab position: ((Display width - aFlapTab width) // 2) @ 0.
	aFlap setProperty: #flap toValue: true.
	aFlap color: (Color blue muchLighter alpha: 0.6).
	aFlap extent: self currentWorld width @ 267.
	aHolder _ AlignmentMorph newRow beSticky beTransparent.

	#(openMenu helpMenu windowsMenu (changesMenu debugMenu ) (playfieldMenu scriptingMenu )) do:
		[:elem |
			(elem isKindOf: Array)
				ifTrue:
					[verticalHolder _ AlignmentMorph newColumn beSticky beTransparent.
					verticalHolder hResizing: #shrinkWrap; inset: 0; centering: #center.
					elem do:
						[:aMenuSymbol |
							verticalHolder addMorphBack: ((aMenu _ self currentHand perform: aMenuSymbol) beSticky; stayUp: true).
							aMenu beSticky.
							aMenu borderWidth: 1.
							aMenu submorphs second delete].
					aHolder addMorphBack: verticalHolder]
				ifFalse:
					[aHolder addMorphBack: ((aMenu _ self currentHand perform: elem) beSticky; stayUp: true).
					aMenu submorphs second delete.
					aMenu beSticky.
					aMenu borderWidth: 1]].

	aFlap addMorphBack: aHolder.

	^ aFlapTab