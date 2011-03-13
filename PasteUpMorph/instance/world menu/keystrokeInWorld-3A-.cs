keystrokeInWorld: evt
	"A keystroke was hit when no keyboard focus was in set, so it is sent here to the world instead.  This current implementation is regrettably hard-coded; until someone cleans this up, you may be tempted to edit this method to suit your personal taste in interpreting cmd-keys issued to the desktop."

	|  aChar isCmd |
	aChar _ evt keyCharacter.
	isCmd _ evt commandKeyPressed and: [Preferences cmdKeysInText].
	isCmd ifTrue:
		[(aChar == $z) ifTrue: [^ self commandHistory undoOrRedoCommand].
		(aChar == $w) ifTrue: [^ SystemWindow closeTopWindow].
		(aChar == $\) ifTrue: [^ SystemWindow sendTopWindowToBack].

		(aChar == $t) ifTrue: [^ self findATranscript: evt].
		(aChar == $b) ifTrue: [^ Browser openBrowser].
		(aChar == $k) ifTrue: [^ Workspace open].

		(aChar == $C) ifTrue: [^ self findAChangeSorter: evt].
		(aChar == $R) ifTrue: [^ self openRecentSubmissionsBrowser: evt].

		(aChar == $r) ifTrue: [^ Display restoreMorphicDisplay].

		(aChar == $W) ifTrue: [^ self invokeWorldMenu: evt]]
			"This last item is a weirdo feature requested by the Open School in Fall of 2000 as a keyhole to the world menu in systems that normally do not offer a world menu"