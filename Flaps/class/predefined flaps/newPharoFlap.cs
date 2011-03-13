newPharoFlap
	"Answer a new default 'Pharo' flap for the left edge of the screen"

	| aFlap aFlapTab aButton aClock buttonColor anOffset bb aFont |
	aFlap := PasteUpMorph newSticky borderWidth: 0.
	aFlapTab := FlapTab new referent: aFlap.
	aFlapTab setName: 'Pharo' translated edge: #left color: (Color gray lighter lighter).
	aFlapTab position: (0 @ ((Display height - aFlapTab height) // 8)).
	aFlapTab setBalloonText: aFlapTab balloonTextForFlapsMenu.

	aFlap cellInset: 14@14.
	aFlap beFlap: true.
	aFlap color: (Color gray muchLighter  alpha: 0.8).
	aFlap extent: 150 @ self currentWorld height.
	aFlap layoutPolicy: TableLayout new.
	aFlap wrapCentering: #topLeft.
	aFlap layoutInset: 2.
	aFlap listDirection: #topToBottom.
	aFlap wrapDirection: #leftToRight.

	"self addProjectNavigationButtonsTo: aFlap."
	anOffset := 16.

	buttonColor :=  Color cyan muchLighter.
	bb := SimpleButtonMorph new target: SmalltalkImage current.
	bb color: buttonColor.
	aButton := bb copy.
	aButton actionSelector: #saveSession.
	aButton setBalloonText: 'Make a complete snapshot of the current state of the image onto disk.' translated.
	aButton label: 'save' translated font: (aFont := Preferences standardEToysFont).
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton := bb copy target: Utilities.
	aButton actionSelector: #updateFromServer.
	aButton label: 'load code updates' translated font: aFont.
	aButton color: buttonColor.
	aButton setBalloonText: 'Check the Pharo server for any new code updates, and load any that are found.' translated.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aButton := SimpleButtonMorph new target: SmalltalkImage current; actionSelector: #aboutThisSystem;
		label: 'about this system' translated font: aFont.
	aButton color: buttonColor.
	aButton setBalloonText: 'click here to find out version information' translated.
	aFlap addCenteredAtBottom: aButton offset: anOffset.

	aFlap addCenteredAtBottom: (Preferences themeChoiceButtonOfColor: buttonColor font: aFont) offset: anOffset.

	^ aFlapTab

"Flaps replaceGlobalFlapwithID: 'Pharo' translated "