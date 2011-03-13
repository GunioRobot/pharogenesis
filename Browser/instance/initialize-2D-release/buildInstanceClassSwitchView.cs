buildInstanceClassSwitchView
	| aView aSwitchView instSwitchView comSwitchView |

	aView _ View new model: self.
	aView window: (0 @ 0 extent: 50 @ 8).
	instSwitchView _ self buildInstanceSwitchView.
	aView addSubView: instSwitchView.
	comSwitchView _ self buildCommentSwitchView.
	aView addSubView: comSwitchView toRightOf: instSwitchView.
	aSwitchView _ self buildClassSwitchView.
	aView addSubView: aSwitchView toRightOf: comSwitchView.
	^aView