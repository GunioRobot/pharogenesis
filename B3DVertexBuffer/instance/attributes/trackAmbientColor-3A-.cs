trackAmbientColor: aBool
	aBool
		ifTrue:[flags _ flags bitOr: VBTrackAmbient]
		ifFalse:[flags _ flags bitAnd: VBTrackAmbient bitInvert32]