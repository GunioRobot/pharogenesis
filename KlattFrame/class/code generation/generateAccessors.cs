generateAccessors
	"
	KlattFrame generateAccessors
	"
	| crtab getter setter |
	crtab _ String with: Character cr with: Character tab.
	self parameterNames
		doWithIndex: [ :selector :i |
			getter _ selector, crtab, '^ self at: ', i printString.
			setter _ selector, ': aNumber', crtab, 'self at: ', i printString,' put: aNumber'.
			self compile: getter classified: 'accessing'.
			self compile: setter classified: 'accessing']