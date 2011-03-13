maybeDismiss: evt with: dismissHandle
	"Ask hand to dismiss my target if mouse comes up in it."

	evt hand obtainHalo: self.
	(dismissHandle containsPoint: evt cursorPoint)
		ifFalse:
			[self delete.
			target addHalo: evt]
		ifTrue:
			[target resistsRemoval ifTrue:
				[(PopUpMenu
					confirm: 'Really throw this away' translated
					trueChoice: 'Yes' translated
					falseChoice: 'Um, no, let me reconsider' translated) ifFalse: [^ self]].
			evt hand removeHalo.
			self delete.
			target dismissViaHalo.
			ActiveWorld presenter flushPlayerListCache]