growNoBecome
 
	| newSelf key |

	newSelf _ self species new: self basicSize.  "This will double the size"
	1 to: self basicSize do:
		[:i | key _ self basicAt: i.
		key == nil ifFalse: [newSelf at: key put: (array at: i)]].
	^newSelf