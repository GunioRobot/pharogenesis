displayOn: aPort
	bitsValid ifFalse:
		[^ Display clippingTo: aPort clipRect do: [super display]].
	windowBits displayOnPort: aPort at: self windowOrigin