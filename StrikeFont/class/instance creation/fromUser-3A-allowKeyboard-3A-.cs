fromUser: priorFont allowKeyboard: aBoolean 
	"rr 3/23/2004 10:02 : made the menu invoked modally, thus allowing
	keyboard control"
	"StrikeFont fromUser"
	"Present a menu of available fonts, and if one is chosen, return it.
	Otherwise return nil."
	| fontList fontMenu style active ptMenu label spec font |
	fontList := StrikeFont actualFamilyNames.
	fontMenu := MenuMorph new defaultTarget: self.
	fontList do: 
		[ :fontName | 
		style := TextStyle named: fontName.
		active := priorFont familyName sameAs: fontName.
		ptMenu := MenuMorph new defaultTarget: self.
		style pointSizes do: 
			[ :pt | 
			(active and: [ pt = priorFont pointSize ]) 
				ifTrue: [ label := '<on>' ]
				ifFalse: [ label := '<off>' ].
			label := label , pt printString , ' pt'.
			ptMenu 
				add: label
				target: fontMenu
				selector: #modalSelection:
				argument: {  fontName. pt  } ].
		style isTTCStyle ifTrue: 
			[ ptMenu 
				add: 'new size'
				target: style
				selector: #addNewFontSizeDialog:
				argument: {  fontName. fontMenu  } ].
		active 
			ifTrue: [ label := '<on>' ]
			ifFalse: [ label := '<off>' ].
		label := label , fontName.
		fontMenu 
			add: label
			subMenu: ptMenu ].
	spec := fontMenu 
		invokeModalAt: ActiveHand position
		in: ActiveWorld
		allowKeyboard: aBoolean.
	spec ifNil: [ ^ nil ].
	style := TextStyle named: spec first.
	style ifNil: [ ^ self ].
	font := style fonts 
		detect: [ :any | any pointSize = spec last ]
		ifNone: [ nil ].
	^ font