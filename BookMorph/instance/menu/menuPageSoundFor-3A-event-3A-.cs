menuPageSoundFor: target event: evt
	| tSpec menu |
	tSpec _ self transitionSpecFor: target.
	menu _ (MenuMorph entitled: 'Choose a sound
(it is now ' , tSpec first , ')') defaultTarget: target.
	SampledSound soundNames do:
		[:soundName |
		menu add: soundName target: target
			selector: #setProperty:toValue:
			argumentList: (Array with: #transitionSpec
								with: (tSpec copy at: 1 put: soundName; yourself))].

	menu popUpEvent: evt in: self world