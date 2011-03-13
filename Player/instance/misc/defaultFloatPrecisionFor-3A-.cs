defaultFloatPrecisionFor: aGetSelector
	"Answer the float position to use in conjunction with a readout for aGetSelector"

	| aSlotName |
	(#(getCursor getNumericValue getNumberAtCursor getCursorWrapped) includes: aGetSelector)
		ifTrue:
			[^ 0.01].
	aSlotName _ Utilities inherentSelectorForGetter: aGetSelector.
	((self elementTypeFor: aSlotName) == #userSlot)
		ifTrue:
			[^ (self slotInfoAt: aSlotName) floatPrecision].

	^ 1