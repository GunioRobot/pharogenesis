trackDiffuseColor: aBool
	aBool
		ifTrue:[flags _ flags bitOr: VBTrackDiffuse]
		ifFalse:[flags _ flags bitAnd: VBTrackDiffuse bitInvert32]