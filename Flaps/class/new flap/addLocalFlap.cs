addLocalFlap
	"Menu command -- let the user add a new project-local flap.  Once the new flap is born, the user can tell it to become a shared flap.  Obtain an initial name and edge for the flap, launch the flap, and also launch a menu governing the flap, so that the user can get started right away with customizing it."

	| aMenu reply aFlapTab aWorld edge |
	aMenu _ MVCMenuMorph entitled: 'Where should the new flap cling?' translated.
	aMenu defaultTarget: aMenu.
	#(left right top bottom) do:
		[:sym | aMenu add: sym asString translated selector: #selectMVCItem: argument: sym].
	edge _ aMenu invokeAt: self currentHand position in: self currentWorld.

	edge ifNotNil:
		[reply _ FillInTheBlank request: 'Wording for this flap: ' translated initialAnswer: 'Flap' translated.
		reply isEmptyOrNil ifFalse:
			[aFlapTab _ self newFlapTitled: reply onEdge: edge.
			(aWorld _ self currentWorld) addMorphFront: aFlapTab.
			aFlapTab adaptToWorld: aWorld.
			aMenu _ aFlapTab buildHandleMenu: ActiveHand.
			aFlapTab addTitleForHaloMenu: aMenu.
			aFlapTab computeEdgeFraction.
			aMenu popUpEvent: ActiveEvent in: ActiveWorld]]
	
