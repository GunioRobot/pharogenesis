menuPageVisualFor: target event: evt

	| tSpec menu subMenu directionChoices |

	tSpec _ self 
		valueOfProperty: #transitionSpec
		ifAbsent: [
			(self valueOfProperty: #bookPage) 
				valueOfProperty: #transitionSpec
				ifAbsent: [{ 'silence' . #none. #none}]
		].
	menu _ (MenuMorph entitled: 'Choose an effect
(it is now ' , tSpec second , ')') defaultTarget: self.
	TransitionMorph allEffects do: [:effect |
		directionChoices _ TransitionMorph directionsForEffect: effect.
		directionChoices isEmpty
		ifTrue: [menu add: effect target: self
					selector: #setProperty:toValue:
					argumentList: (Array with: #transitionSpec
									with: (Array with: tSpec first with: effect with: #none))]
		ifFalse: [subMenu _ MenuMorph new.
				directionChoices do:
					[:dir |
					subMenu add: dir target: self
						selector: #setProperty:toValue:
						argumentList: (Array with: #transitionSpec
									with: (Array with: tSpec first with: effect with: dir))].
				menu add: effect subMenu: subMenu]].

	menu popUpEvent: evt in: self world