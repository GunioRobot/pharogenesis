makeIsolatedCodePane
	| msgName |

	(msgName _ self selectedMessageName) ifNil: [^ self beep].
	MethodHolder makeIsolatedCodePaneForClass: self selectedClassOrMetaClass selector: msgName