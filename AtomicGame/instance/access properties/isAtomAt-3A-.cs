isAtomAt: aPosition 
	| morph |
	morph _ self somethingAt: aPosition.
^ morph notNil and:[ morph isAtom]