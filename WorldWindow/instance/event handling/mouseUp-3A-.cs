mouseUp: evt

	(self panelRect containsPoint: evt cursorPoint)
		ifTrue: [model becomeTheActiveWorldWith: evt]