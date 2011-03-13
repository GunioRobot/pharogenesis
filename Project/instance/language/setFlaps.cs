setFlaps

	| flapTabs flapIDs sharedFlapTabs |
	flapTabs := ActiveWorld flapTabs.
	flapIDs := flapTabs collect: [:tab | tab knownName].
	flapTabs
		do: [:tab | tab isGlobalFlap
						ifTrue: [Flaps removeFlapTab: tab keepInList: false.
							tab currentWorld reformulateUpdatingMenus]
						ifFalse: [| referent | 
							referent := tab referent.
							referent isInWorld
								ifTrue: [referent delete].
							tab delete]].
	sharedFlapTabs := Flaps classPool at: #SharedFlapTabs.
	flapIDs
		do: [:id | 
			id = 'Squeak' translated
				ifTrue: [sharedFlapTabs add: Flaps newSqueakFlap]].
	2 timesRepeat: [flapIDs do: [:id | Flaps enableDisableGlobalFlapWithID: id]].
	ActiveWorld flapTabs
		do: [:flapTab | flapTab isCurrentlyTextual
				ifTrue: [flapTab changeTabText: flapTab knownName]].
	Flaps positionNavigatorAndOtherFlapsAccordingToPreference.
	