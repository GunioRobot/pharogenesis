changeTextFontAlphabeticalMenu
	| dict startIndex stopIndex currrentFont currentFamilyMember fontMenu fams members styleName label  tag  ptMenu spec newFont attr applyStart applyStop allFontFamilies removeSet unBold unSlanted unSlantedUnBold alphaMenu itemFont alphaIncludesCurrent alphaLabel |

	startIndex := self startIndex.
	stopIndex := self stopIndex-1 min: paragraph text size.
	allFontFamilies := LogicalFontManager current allFamilies.
	currrentFont := paragraph text fontAt: startIndex withStyle: paragraph textStyle.
	currentFamilyMember := self familyMemberFor: currrentFont fromFamilies: allFontFamilies.
	fontMenu := MenuMorph new defaultTarget: self.
	dict := self alphabeticalGroupsFor: allFontFamilies size: 15.
	dict keys asSortedCollection do:[:k |
		alphaMenu := MenuMorph new defaultTarget: self. 
		fams := dict at: k.
		alphaIncludesCurrent := false.
		fams do:[:family |
			members := family members reject:[:mem | mem simulated].
			"reject any members that are simply bold, italic, or boldItalic versions of other members"
			removeSet := Set new.
			members do:[:mem |
				(mem weightValue = 700 and:[mem slantValue ~= 0])
					ifTrue:[
						unSlantedUnBold := family 
							closestMemberWithStretchValue: mem stretchValue
							weightValue: 400 
							slantValue: 0.
						unSlantedUnBold = mem ifFalse:[removeSet add: mem]]
					ifFalse:[
						mem weightValue = 700 
							ifTrue:[
								unBold := family 
									closestMemberWithStretchValue: mem stretchValue
									weightValue: 400 
									slantValue: mem slantValue.
								unBold = mem ifFalse:[removeSet add: mem]].
						mem slantValue ~= 0 
							ifTrue:[
								unSlanted := family 
									closestMemberWithStretchValue: mem stretchValue
									weightValue: mem weightValue 
									slantValue: 0.
								unSlanted = mem ifFalse:[removeSet add: mem]]]].				
			members := members copyWithoutAll: removeSet. 
			members := members asSortedCollection asArray.
			members do:[:member |
				styleName := member styleName.
				(#('book' 'normal' 'regular' 'roman' 'upright') includes: styleName asLowercase)
					ifTrue:[styleName := ''].
				(styleName notEmpty and:[member simulated]) 
					ifTrue:[styleName := '(', styleName, ')'].
				label := family familyName, ' ',styleName.
				self fontMenuItemsDisplayWithMenuFont ifFalse:[
					itemFont := member asLogicalFontOfPointSize: Preferences standardMenuFont pointSize.
					(itemFont isSymbolFont or:[(itemFont hasDistinctGlyphsForAll: label) not])
						ifTrue:[itemFont := nil]].
				alphaIncludesCurrent := alphaIncludesCurrent or:[member = currentFamilyMember].
				tag := member = currentFamilyMember ifTrue:['<on>'] ifFalse:['<off>'].
				label := tag , label.
				ptMenu := self 
					pointSizeMenuForFamilyMember: member
					parentMenu:fontMenu
					active: member = currentFamilyMember
					activePointSize: currrentFont pointSize.
				alphaMenu add: label subMenu: ptMenu. 				
				itemFont ifNotNil:[alphaMenu lastItem font: itemFont] ]].
		alphaLabel := alphaIncludesCurrent ifTrue:['<on>'] ifFalse:['<off>'].
		alphaLabel := alphaLabel, k.
		fontMenu add: alphaLabel subMenu: alphaMenu.
		"alphaIncludesCurrent ifTrue:[fontMenu lastItem color: Color red ]"].
	spec := fontMenu invokeModalAt: ActiveHand position in: ActiveWorld allowKeyboard: true.
	spec ifNil:[^nil].
	newFont := LogicalFont 
		familyName: spec first family familyName 
		pointSize: spec last 
		stretchValue: spec first stretchValue 
		weightValue: spec first weightValue 
		slantValue: spec first slantValue.
	newFont ifNil:[^self].
	attr := TextFontReference toFont: newFont.
	applyStart := stopIndex >= startIndex ifTrue:[startIndex] ifFalse:[1].
	applyStop := stopIndex >= startIndex ifTrue:[stopIndex] ifFalse:[paragraph text size].
	paragraph text addAttribute: attr from: applyStart to: applyStop.
	paragraph composeAll.
	self recomputeInterval			