makeIsolatedCodePane
	| msgName |

	(msgName := self selectedMessageName) ifNil: [^ Beeper beep].
	MethodHolder makeIsolatedCodePaneForClass: self selectedClassOrMetaClass selector: msgName