hasDismissButton
	submorphs isEmptyOrNil ifTrue: [^ false].
	^ (submorphs first allMorphs detect:
		[:possible |  (possible isKindOf: SimpleButtonMorph) and: [possible actionSelector == #dismiss]]
			ifNone: [nil]) notNil