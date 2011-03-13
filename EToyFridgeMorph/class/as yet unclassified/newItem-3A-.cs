newItem: newMorph

	| theFridge fridgeWorld trialRect |

	theFridge _ Project named: 'Fridge'.
	theFridge ifNil: [^self newItems add: newMorph].
	fridgeWorld _ theFridge world.
	trialRect _ fridgeWorld randomBoundsFor: newMorph.
	fridgeWorld 
		addMorphFront: (newMorph position: trialRect topLeft);
		startSteppingSubmorphsOf: newMorph
