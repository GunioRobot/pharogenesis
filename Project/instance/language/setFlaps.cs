setFlaps

	| flapTabs flapIDs sharedFlapTabs navigationMorph |
	flapTabs _ ActiveWorld flapTabs.
	flapIDs _ flapTabs collect: [:tab | tab knownName].
	flapTabs
		do: [:tab | (tab isMemberOf: ViewerFlapTab)
				ifFalse: [tab isGlobalFlap
						ifTrue: [Flaps removeFlapTab: tab keepInList: false.
							tab currentWorld reformulateUpdatingMenus]
						ifFalse: [| referent | 
							referent _ tab referent.
							referent isInWorld
								ifTrue: [referent delete].
							tab delete]]].
	sharedFlapTabs _ Flaps classPool at: #SharedFlapTabs.
	flapIDs
		do: [:id | 
			id = 'Navigator' translated
				ifTrue: [sharedFlapTabs add: Flaps newNavigatorFlap].
			id = 'Widgets' translated
				ifTrue: [sharedFlapTabs add: Flaps newWidgetsFlap].
			id = 'Tools' translated
				ifTrue: [sharedFlapTabs add: Flaps newToolsFlap].
			id = 'Squeak' translated
				ifTrue: [sharedFlapTabs add: Flaps newSqueakFlap].
			id = 'Supplies' translated
				ifTrue: [sharedFlapTabs add: Flaps newSuppliesFlap].
			id = 'Stack Tools' translated
				ifTrue: [sharedFlapTabs add: Flaps newStackToolsFlap].
			id = 'Painting' translated
				ifTrue: [sharedFlapTabs add: Flaps newPaintingFlap].
			id = 'Objects' translated
				ifTrue: [sharedFlapTabs add: Flaps newObjectsFlap ]].
	2 timesRepeat: [flapIDs do: [:id | Flaps enableDisableGlobalFlapWithID: id]].
	ActiveWorld flapTabs
		do: [:flapTab | flapTab isCurrentlyTextual
				ifTrue: [flapTab changeTabText: flapTab knownName]].
	Flaps positionNavigatorAndOtherFlapsAccordingToPreference.
	navigationMorph _ World findDeeplyA: ProjectNavigationMorph preferredNavigator.
	navigationMorph isNil
		ifTrue: [^ self].
	navigationMorph allMorphs
		do: [:morph | morph class == SimpleButtonDelayedMenuMorph
				ifTrue: [(morph findA: ImageMorph) isNil
						ifTrue: [| label | 
							label _ morph label.
							label isNil
								ifFalse: [| name | 
									name _ morph knownName.
									name isNil
										ifTrue: [morph name: label.
											name _ label].
									morph label: name translated]]]]