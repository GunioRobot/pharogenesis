menuPageVisualFor: target event: evt
	| tSpec menu subMenu directionChoices |
	tSpec _ self transitionSpecFor: target.
	menu _ (MenuMorph entitled: ('Choose an effect
(it is now {1})' translated format:{tSpec second asString translated})) defaultTarget: target.
	TransitionMorph allEffects do:
		[:effect |
		directionChoices _ TransitionMorph directionsForEffect: effect.
		directionChoices isEmpty
		ifTrue: [menu add: effect asString translated target: target
					selector: #setProperty:toValue:
					argumentList: (Array with: #transitionSpec
									with: (Array with: tSpec first with: effect with: #none))]
		ifFalse: [subMenu _ MenuMorph new.
				directionChoices do:
					[:dir |
					subMenu add: dir asString translated target: target
						selector: #setProperty:toValue:
						argumentList: (Array with: #transitionSpec
									with: (Array with: tSpec first with: effect with: dir))].
				menu add: effect asString translated subMenu: subMenu]].

	menu popUpEvent: evt in: self world