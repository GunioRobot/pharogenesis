pointSizeMenuForFamilyMember: aFontFamilyMember parentMenu: aMenuMorph active: aBoolean activePointSize: aNumberOrNil
		
	| ptMenu style pointSizes activePt ptLabel onLabel offLabel selector target |
	ptMenu := MenuMorph new defaultTarget: self.
	style := TextStyle named: aFontFamilyMember family familyName.
	pointSizes := style 
		ifNil:[
			pointSizes := #(6 8 10 11 12 15 18 20 22 24 26 28 30 36 42 52 72).
			aNumberOrNil ifNotNil:[
				pointSizes := (pointSizes copyWith: aNumberOrNil reduce) asSet asSortedCollection] ]
		ifNotNil:[
			pointSizes := style pointSizes].
	pointSizes do:[:ptSize |
		activePt := aBoolean and:[ptSize = aNumberOrNil].
		aNumberOrNil isNil
			ifTrue:[onLabel := ''. offLabel := '']
			ifFalse:[onLabel := '<on>'. offLabel := '<off>'].
		ptLabel := activePt
			ifTrue:[onLabel, ptSize printString, ' pt']
			ifFalse:[offLabel, ptSize printString, ' pt'].
		ptMenu 
			add: ptLabel 
			target: aMenuMorph
			selector: #modalSelection:
			argument: {aFontFamilyMember. ptSize}].	
		(style isNil or:[style isTTCStyle ]) ifTrue:[
			selector := style 
				ifNil:[#otherFontSizeDialog:] 
				ifNotNil:[#addNewFontSizeDialog: ].
			target := style ifNil:[self].
			ptMenu 
				addLine;
				add: 'Other size...' translated
					target: target
					selector: selector
					argument: {aFontFamilyMember. aMenuMorph}].
	^ptMenu