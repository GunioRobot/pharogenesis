composedWithLocal: aColorTransform
	| cm |
	cm := self clone.
	cm rAdd: self rAdd + (aColorTransform rAdd * self rMul).
	cm rMul: self rMul * aColorTransform rMul.
	cm gAdd: self gAdd + (aColorTransform gAdd * self gMul).
	cm gMul: self gMul * aColorTransform gMul.
	cm bAdd: self bAdd + (aColorTransform bAdd * self bMul).
	cm bMul: self bMul * aColorTransform bMul.
	cm aAdd: self aAdd + (aColorTransform aAdd * self aMul).
	cm aMul: self aMul * aColorTransform aMul.
	^cm