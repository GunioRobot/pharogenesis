fontMenuForStyle: styleName target: target selector: selector highlight: currentFont 
	"Offer a font menu for the given style. If one is selected, pass 
	that font to target with a  
	call to selector. The fonts will be displayed in that font."
	| aMenu |
	aMenu := MenuMorph entitled: styleName.
	(TextStyle named: styleName)
		ifNotNilDo: [:s | s isTTCStyle
				ifTrue: [aMenu
						add: 'New Size'
						target: self
						selector: #chooseTTCFontSize:
						argument: {styleName. target. selector}]].
	(self pointSizesFor: styleName)
		do: [:pointSize | 
			| font subMenu | 
			font := (self named: styleName)
						fontOfPointSize: pointSize.
			subMenu := self
						emphasisMenuForFont: font
						target: target
						selector: selector
						highlight: (currentFont
								ifNotNilDo: [:cf | (cf familyName = styleName
											and: [cf pointSize = font pointSize])
										ifTrue: [currentFont emphasis]]).
			subMenu
				ifNil: [aMenu
						add: pointSize asString , ' Point'
						target: target
						selector: selector
						argument: font]
				ifNotNil: [aMenu add: pointSize asString , ' Point' subMenu: subMenu].
			aMenu lastItem font: font.
			currentFont
				ifNotNilDo: [:cf | (cf familyName = styleName
							and: [cf pointSize = font pointSize])
						ifTrue: [aMenu lastItem color: Color blue darker]]].
	^ aMenu