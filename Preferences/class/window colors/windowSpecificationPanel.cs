windowSpecificationPanel
	"Preferences windowSpecificationPanel"
	| aPanel buttonRow aButton aRow aSwatch aColor aWindow aMiniWorld |
	aPanel _ AlignmentMorph newColumn hResizing: #shrinkWrap; vResizing: #shrinkWrap.

	aPanel addMorph: (buttonRow _ AlignmentMorph newRow color: (aColor _ Color tan lighter)).
	
	aButton _ SimpleButtonMorph new target: self.
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
			aButton _ aButton fullCopy
				label: quad first;
				actionSelector: quad second;
				color: (Color colorFrom: quad third);
				setBalloonText: quad fourth;
				yourself.
			buttonRow addMorphBack: aButton.
			buttonRow addTransparentSpacerOfSize: 10@0].

	self windowColorClasses do:
		[:aClassName | 
			aRow _ AlignmentMorph newRow color: aColor.
			aSwatch _ ColorSwatch new
				target: self;
				getSelector: #windowColorFor:;
				putSelector: #setWindowColorFor:to:;
				argument: aClassName;
				extent: (40 @ 20);
				yourself.
			aRow addMorphFront: aSwatch.
			aRow addTransparentSpacerOfSize: (12 @ 1).
			aRow addMorphBack: (StringMorph contents: aClassName font: TextStyle defaultFont).
			aPanel addMorphBack: aRow].

	 Smalltalk isMorphic
                ifTrue:
                        [buttonRow _ buttonRow fullCopy removeAllMorphs.
					buttonRow addTransparentSpacerOfSize: 25@0.
					aButton _ aButton fullCopy color: Color tan muchLighter.
					aButton label: 'Update Tools Flap'; target: Utilities; actionSelector: #replaceToolsFlap.
					buttonRow addMorphBack: aButton.
					aButton setBalloonText: 'Press here to place tools which use the above window-color choices  into the Tools flap.'.
					aPanel addMorphBack: buttonRow.

					aWindow _ aPanel wrappedInWindowWithTitle: 'Window Colors'.
                        self currentHand attachMorph: aWindow.
					aWindow world startSteppingSubmorphsOf: aPanel.]
                ifFalse:
                        [(aMiniWorld _ MVCWiWPasteUpMorph newWorldForProject: nil)
						addMorph: aPanel.
                           aMiniWorld startSteppingSubmorphsOf: aPanel.
                        MorphWorldView openOn: aMiniWorld
                                label: 'Window Colors'
                                extent: aMiniWorld fullBounds extent]