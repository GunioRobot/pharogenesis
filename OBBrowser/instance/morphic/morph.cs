morph
	| window |
	window := SystemWindow labelled: self defaultLabel.
	window model: self.
	panels isEmpty ifFalse: [self morphicPanelLayout addMorphsTo: window].
	^window