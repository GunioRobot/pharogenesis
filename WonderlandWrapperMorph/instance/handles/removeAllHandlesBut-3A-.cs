removeAllHandlesBut: aHandle
	| halo |
	halo _ self halo.
	halo == nil ifFalse:[halo removeAllHandlesBut: aHandle].