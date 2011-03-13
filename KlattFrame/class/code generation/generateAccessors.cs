generateAccessors
	"
	KlattFrame generateAccessors
	"
	| crtab getter setter |
	crtab := String with: Character cr with: Character tab.
	self parameterNames
		doWithIndex: [ :selector :i |
			getter := selector, crtab, '^ self at: ', i printString.
			setter := selector, ': aNumber', crtab, 'self at: ', i printString,' put: aNumber'.
			self compile: getter classified: 'accessing'.
			self compile: setter classified: 'accessing']