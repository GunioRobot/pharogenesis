buildInstanceClassSwitchView
	| aView aSwitchView instSwitchView comSwitchView |

	aView := View new model: self.
	aView window: (0 @ 0 extent: 50 @ 8).
	instSwitchView := self buildInstanceSwitchView.
	aView addSubView: instSwitchView.
	comSwitchView := self buildCommentSwitchView.
	aView addSubView: comSwitchView toRightOf: instSwitchView.
	aSwitchView := self buildClassSwitchView.
	aView addSubView: aSwitchView toRightOf: comSwitchView.
	^aView