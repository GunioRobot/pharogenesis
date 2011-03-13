haloThemeRadioButtons
	"Answer a column of butons representing the choices of halo theme"

	| buttonColumn aRow aRadioButton aStringMorph |
	buttonColumn _ AlignmentMorph newColumn beTransparent.
	#(	(iconicHaloSpecifications iconic iconicHalosInForce	'circular halos with icons inside')
		(classicHaloSpecs	classic	classicHalosInForce		'plain circular halos')
		(simpleFullHaloSpecifications		simple	simpleHalosInForce	'fewer, larger halos')
		(customHaloSpecs	custom	customHalosInForce		'customizable halos')) do:

		[:quad |
			aRow _ AlignmentMorph newRow beTransparent.
			aRow addMorph: (aRadioButton _ UpdatingThreePhaseButtonMorph radioButton).
			aRadioButton target: Preferences.
			aRadioButton setBalloonText: quad fourth.
			aRadioButton actionSelector: #installHaloTheme:.
			aRadioButton getSelector: quad third.
			aRadioButton arguments: (Array with: quad first).
			aRow addTransparentSpacerOfSize: (4 @ 0).
			aRow addMorphBack: (aStringMorph _ StringMorph contents: quad second asString).
			aStringMorph setBalloonText: quad fourth.
			buttonColumn addMorphBack: aRow].
	^ buttonColumn

	"self currentHand attachMorph: Preferences haloThemeRadioButtons"