displayClippingTo: rect

	| bigRect |
	bigRect := rect insetBy: -1.
	self clippingTo: bigRect do: [Display clippingTo: bigRect do: [self display]]
