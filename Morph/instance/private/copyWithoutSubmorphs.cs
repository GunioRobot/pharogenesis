copyWithoutSubmorphs

	^ self clone
		privateOwner: nil;
		privateSubmorphs: EmptyArray;
		privateBounds: (bounds origin corner: bounds corner)  "deep-copy bounds"