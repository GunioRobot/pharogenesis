upMember
| temp |
	temp := (self archive members) at: memberIndex.
	self archive members at: memberIndex put: (self archive members at: memberIndex  -1).
	self archive members at: (memberIndex  -1) put: temp.
	self memberIndex:  0.
	self changed: #memberList.