trackEmissionColor: aBool
	aBool
		ifTrue:[flags _ flags bitOr: VBTrackEmission]
		ifFalse:[flags _ flags bitAnd: VBTrackEmission bitInvert32]