addGlobalFlaps 
	"Must make global flaps adapt to world.  Do this even if not shown, so the old world will not be pointed at by the flaps."
	| use thisWorld |

	use _ true.
	(Preferences valueOfFlag: #useGlobalFlaps) ifFalse: [use _ false].
	Project current flapsSuppressed ifTrue: [use _ false].
	"Smalltalk isMorphic ifFalse: [use _ false]."
	thisWorld _ use 
		ifTrue: [self]
		ifFalse: [(PasteUpMorph new) initForProject:  "fake to be flap owner"
						WorldState new initForWorld;
					bounds: (0@0 extent: 4000@4000);
					viewBox: (0@0 extent: 4000@4000)].
	
	Utilities globalFlapTabs do: [:aFlapTab |
		(aFlapTab world == thisWorld) ifFalse:
			[thisWorld addMorphFront: aFlapTab.
			aFlapTab adaptToWorld: thisWorld].	"always do"
		use ifTrue: [
			aFlapTab spanWorld.
			aFlapTab adjustPositionAfterHidingFlap.
			aFlapTab flapShowing ifTrue: [aFlapTab showFlap]]].

"
	Utilities clobberFlapTabList.
	Utilities initializeStandardFlaps.
	self currentWorld deleteAllFlapArtifacts.
	self currentWorld addGlobalFlaps.
"