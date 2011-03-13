closeMyFlapIfAny

	| myFlap allTabs myTab myWorld |

	myWorld _ self world.
	myFlap _ self nearestOwnerThat: [ :each | each isFlap].
	myFlap ifNil: [^self].
	allTabs _ myWorld submorphs select: [ :each | each isFlapTab].
	myTab _ allTabs detect: [ :each | each referent == myFlap] ifNone: [^self].
	myTab hideFlap.
	myWorld displayWorldSafely.
	
