defaultFloatPrecisionFor: aGetSelector
	| aSlotName |
	(#(getCursor getNumericValue getCursorWrapped) includes: aGetSelector)
		ifTrue:
			[^ 0.01].
	aSlotName _ Utilities inherentSelectorForGetter: aGetSelector.
	((self elementTypeFor: aSlotName) == #userSlot)
		ifTrue:
			[^ (self slotInfoAt: aSlotName) floatPrecision].

	^ 1