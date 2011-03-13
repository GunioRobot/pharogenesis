openFactoredPanelWithWidth: aWidth 
	"Open up a preferences panel of the given width"

	"Preferences openFactoredPanelWithWidth: 325"
	| tabbedPalette controlPage window playfield aColor aFont maxEntriesPerCategory tabsMorph anExtent aPanel |
	aFont _ StrikeFont familyName: 'NewYork' size: 19.
	aPanel _ PreferencesPanel new.
	aColor _ aPanel defaultBackgroundColor.
	tabbedPalette _ TabbedPalette newSticky.
	(tabsMorph _ tabbedPalette tabsMorph) color: aColor darker;
		 highlightColor: Color red regularColor: Color brown darker darker.
	maxEntriesPerCategory _ 0.
	"tabbedPalette addTabFor: self helpPaneForFactoredPanel font: aFont.  
	LATER!"
	self factoredCategories
		do: 
			[:aCat | 
			controlPage _ AlignmentMorph newColumn beSticky color: aColor.
			controlPage borderColor: aColor;
				 layoutInset: 4.
			aCat second
				do: [:aPrefSymbol | controlPage
						addMorphBack: (Preferences
								buttonRepresenting: aPrefSymbol
								wording: aPrefSymbol
								color: nil)].
			controlPage setNameTo: aCat first asString.
			aCat first == #halos
				ifTrue: [aPanel addHaloControlsTo: controlPage].
			tabbedPalette addTabFor: controlPage font: aFont.
			aCat first = 'search results' ifTrue:
				[(tabbedPalette tabNamed: aCat first) setBalloonText:
					'Use cmd-f to find preferences by keyword; the results of your search will show up here'].
			maxEntriesPerCategory _ maxEntriesPerCategory max: aCat second size].
	tabbedPalette selectTabNamed: 'general'.
	tabsMorph rowsNoWiderThan: aWidth.
	playfield _ Morph newSticky.
	anExtent _ aWidth @ (25 + tabsMorph height + (20 * maxEntriesPerCategory)).
	playfield extent: anExtent.
	playfield color: aColor.
	playfield addMorphBack: tabbedPalette.
	self couldOpenInMorphic
		ifTrue: [window _ (SystemWindow labelled: 'Preferences')
						model: aPanel.
			window on: #keyStroke send: #keyStroke: to: aPanel.
			window
				bounds: (100 @ 100 - (0 @ window labelHeight + window borderWidth) extent: playfield extent + (2 * window borderWidth)).
			window
				addMorph: playfield
				frame: (0 @ 0 extent: 1 @ 1).
			window updatePaneColors.
			window setProperty: #minimumExtent toValue: anExtent + (2 @ 2).
			window position: 200 @ 20.
			self currentHand attachMorph: window.
			self currentWorld startSteppingSubmorphsOf: window]
		ifFalse:
			[(window _ MVCWiWPasteUpMorph newWorldForProject: nil) addMorph: playfield.
			window startSteppingSubmorphsOf: playfield.
			MorphWorldView
				openOn: window
				label: 'Preferences'
				extent: playfield extent]