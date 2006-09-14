windowSpecificationPanel
	"Put up a panel for specifying window colors"

	"Preferences windowSpecificationPanel"
	| aPanel buttonRow aButton aRow aSwatch aColor aWindow aMiniWorld aStringMorph |
	aPanel := AlignmentMorph newColumn hResizing: #shrinkWrap; vResizing: #shrinkWrap;
		layoutInset: 0.

	aPanel addMorph: (buttonRow := AlignmentMorph newRow color: (aColor := Color tan lighter)).
	
	buttonRow addTransparentSpacerOfSize: 2@0.
	buttonRow addMorphBack: (SimpleButtonMorph new label: '?'; target: self; actionSelector: #windowColorHelp; setBalloonText: 'Click for an explanation of this panel'; color: Color veryVeryLightGray; yourself).
	buttonRow addTransparentSpacerOfSize: 8@0.
	#(	('Bright' 	installBrightWindowColors	yellow
					'Use standard bright colors for all windows.')
		('Pastel'		installPastelWindowColors	paleMagenta
					'Use standard pastel colors for all windows.')
		('White'	installUniformWindowColors		white
					'Use white backgrounds for all standard windows.')) do:

		[:quad |
			aButton := (SimpleButtonMorph new target: self)
				label: quad first;
				actionSelector: quad second;
				color: (Color colorFrom: quad third);
				setBalloonText: quad fourth;
				yourself.
			buttonRow addMorphBack: aButton.
			buttonRow addTransparentSpacerOfSize: 10@0].

	self windowColorTable do:
		[:colorSpec | 
			aRow _ AlignmentMorph newRow color: aColor.
			aSwatch _ ColorSwatch new
				target: self;
				getSelector: #windowColorFor:;
				putSelector: #setWindowColorFor:to:;
				argument: colorSpec classSymbol;
				extent: (40 @ 20);
				setBalloonText: 'Click here to change the standard color to be used for ', colorSpec wording, ' windows.';
				yourself.
			aRow addMorphFront: aSwatch.
			aRow addTransparentSpacerOfSize: (12 @ 1).
			aRow addMorphBack: (aStringMorph := StringMorph contents: colorSpec wording font: TextStyle defaultFont).
			aStringMorph setBalloonText: colorSpec helpMessage.
			aPanel addMorphBack: aRow].

	 Smalltalk isMorphic
                ifTrue:
                        [aWindow := aPanel wrappedInWindowWithTitle: 'Window Colors'.
					" don't allow the window to be picked up by clicking inside "
					aPanel on: #mouseDown send: #yourself to: aPanel.
					self currentWorld addMorphCentered: aWindow.
					aWindow activateAndForceLabelToShow ]
                ifFalse:
                        [(aMiniWorld := MVCWiWPasteUpMorph newWorldForProject: nil)
						addMorph: aPanel.
                           aMiniWorld startSteppingSubmorphsOf: aPanel.
                        MorphWorldView openOn: aMiniWorld
                                label: 'Window Colors'
                                extent: aMiniWorld fullBounds extent]