removeAllWrappers
	submorphs do:[:m|
		(m isKindOf: WonderlandWrapperMorph) ifTrue:[m delete]].