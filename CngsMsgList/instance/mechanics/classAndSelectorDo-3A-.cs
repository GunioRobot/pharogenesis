classAndSelectorDo: blockOfTwoArgs
	| class selector |
	class _ parent selectedClassOrMetaClass.
	selector _ parent selectedMessageName.
	((class == nil) | (selector == nil)) ifTrue: [^ self].
	^ blockOfTwoArgs value: class value: selector