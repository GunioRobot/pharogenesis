currentTextInButton

	| existing |

	existing _ self currentTextMorphsInButton.
	existing isEmpty ifTrue: [^nil].
	^existing first
