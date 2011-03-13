grow 
	| newSelf key |
	newSelf _ self species new: self basicSize + self growSize.
	1 to: self basicSize do:
		[:i | key _ self basicAt: i.
		key == nil ifFalse: [newSelf at: key put: (array at: i)]].
	self become: newSelf