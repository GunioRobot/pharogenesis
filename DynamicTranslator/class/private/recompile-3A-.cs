recompile: aClass
	| selectors |
	selectors _ aClass selectors.
	('Recompiling ' , aClass name)
		displayProgressAt: Sensor cursorPoint
		from: 0 to: selectors size
		during: [:bar |
			selectors doWithIndex: [:sel :i |
				bar value: i.
				aClass recompile: sel from: aClass]]