makeIsolatedCodePane
	| msgName |

	(msgName _ self selectedMessageName) ifNil: [^ Beeper beep].
	MethodHolder makeIsolatedCodePaneForClass: self selectedClassOrMetaClass selector: msgName