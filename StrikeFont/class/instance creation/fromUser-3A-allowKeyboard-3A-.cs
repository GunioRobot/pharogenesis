fromUser: priorFont allowKeyboard: aBoolean
	"rr 3/23/2004 10:02 : made the menu invoked modally, thus allowing
	keyboard control" 
	"StrikeFont fromUser"
	"Present a menu of available fonts, and if one is chosen, return it.
	Otherwise return nil."

	| fontList fontMenu style active ptMenu label spec font |
	fontList _ StrikeFont actualFamilyNames.
	fontMenu _ MenuMorph new defaultTarget: self.
	fontList do: [:fontName |
		style _ TextStyle named: fontName.
		active _ priorFont familyName sameAs: fontName.
		ptMenu _ MenuMorph new defaultTarget: self.
		style pointSizes do: [:pt |
			(active and:[pt = priorFont pointSize]) 
				ifTrue:[label _ '<on>'] 
				ifFalse:[label _ '<off>'].
			label _ label, pt printString, ' pt'.
			ptMenu add: label 
				target: fontMenu
				selector: #modalSelection:
				argument: {fontName. pt}].
		style isTTCStyle ifTrue: [
			ptMenu add: 'new size'
				target: style selector: #addNewFontSizeDialog: argument: {fontName. fontMenu}.
		].
		active ifTrue:[label _ '<on>'] ifFalse:[label _ '<off>'].
		label _ label, fontName.
		fontMenu add: label subMenu: ptMenu].
	spec _ fontMenu invokeModalAt: ActiveHand position in: ActiveWorld allowKeyboard: aBoolean.
	spec ifNil: [^ nil].
	style _ TextStyle named: spec first.
	style ifNil: [^ self].
	font _ style fonts detect: [:any | any pointSize = spec last] ifNone: [nil].
	^ font