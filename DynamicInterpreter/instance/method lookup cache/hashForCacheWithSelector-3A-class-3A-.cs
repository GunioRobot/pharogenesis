hashForCacheWithSelector: selector class: class
	| selHash |
	self inline: true.
	(self isIntegerObject: selector)
		ifTrue:
		["We tolerate integers as selectors for now. This allows
		an image to have selectors scrunched out to save space."
		selHash _ self integerValueOf: selector]
		ifFalse:
		[selHash _ self hashBitsOf: messageSelector].

	^ selHash bitXor: (self hashBitsOf: class)