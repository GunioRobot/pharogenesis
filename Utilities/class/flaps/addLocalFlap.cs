addLocalFlap

	| aMenu reply aFlapTab aWorld |

	aMenu _ MVCMenuMorph entitled: 'Where should the new flap cling?'.
	aMenu defaultTarget: aMenu.
	#(left right top bottom) do:
		[:sym | aMenu add: sym selector: #selectMVCItem: argument: sym].
	reply _ aMenu invokeAt: self currentHand position in: self currentWorld.
	reply ifNotNil:
		[aFlapTab _ self newFlapTitled: 'Flap' onEdge: reply.
		(aWorld _ self currentWorld) addMorphFront: aFlapTab.
		aFlapTab adaptToWorld: aWorld]
	
