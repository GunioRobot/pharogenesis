trackSpecularColor: aBool
	aBool
		ifTrue:[flags _ flags bitOr: VBTrackSpecular]
		ifFalse:[flags _ flags bitAnd: VBTrackSpecular bitInvert32]