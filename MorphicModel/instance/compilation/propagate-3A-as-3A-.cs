propagate: value as: partStoreSelector
	model ifNil: [^ self].
"
	Later we can cache this for more speed as follows...
	(partName == cachedPartName and: [slotName == cachedSlotName])
		ifFalse: [cachedPartName _ partName.
				cachedSlotName _ slotName.
				cachedStoreSelector _ (slotName , partStoreSelector) asSymbol].
	model perform: cachedStoreSelector with: value].
"
	model perform: (self slotSelectorFor: partStoreSelector) with: value