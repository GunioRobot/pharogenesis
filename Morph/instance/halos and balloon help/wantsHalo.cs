wantsHalo
	| topOwner |
	^ (topOwner _ self topRendererOrSelf owner) ~~ nil and:
		[topOwner wantsHaloFor: self]