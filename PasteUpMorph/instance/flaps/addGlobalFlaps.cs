addGlobalFlaps 
	"Must make global flaps adapt to world.  Do this even if not shown, so the old world will not be pointed at by the flaps."

	| use thisWorld |
	use _ Flaps sharedFlapsAllowed.
	CurrentProjectRefactoring currentFlapsSuppressed ifTrue: [use _ false].
	"Smalltalk isMorphic ifFalse: [use _ false]."
	thisWorld _ use 
		ifTrue: [self]
		ifFalse: [PasteUpMorph new initForProject:  "fake to be flap owner"
						WorldState new;
					bounds: (0@0 extent: 4000@4000);
					viewBox: (0@0 extent: 4000@4000)].
	
	Flaps globalFlapTabsIfAny do: [:aFlapTab |
		(CurrentProjectRefactoring isFlapEnabled: aFlapTab) ifTrue:
			[(aFlapTab world == thisWorld) ifFalse:
				[thisWorld addMorphFront: aFlapTab.
				aFlapTab adaptToWorld: thisWorld].	"always do"
			use ifTrue:
				[aFlapTab spanWorld.
				aFlapTab adjustPositionAfterHidingFlap.
				aFlapTab flapShowing ifTrue: [aFlapTab showFlap]]]]