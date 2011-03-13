rehashWithoutBecome
	| newSelf key |
	newSelf := self species new: self size.
	1 to: self basicSize do:
		[:i | key := self basicAt: i.
		key == nil ifFalse: [newSelf at: key put: (array at: i)]].
	^newSelf