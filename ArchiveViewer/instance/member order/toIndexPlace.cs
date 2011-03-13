toIndexPlace
| index max temp |
max := self archive members size.
index :=0.
[index := (FillInTheBlank
		request: 'To which index '
		initialAnswer:  '1'
		centerAt: Display center) asInteger.
		index between: 1 and: max] whileFalse.
	temp := (self archive members) at: memberIndex.
	self archive members at: memberIndex put: (self archive members at: index).
	self archive members at: index put: temp.
	self memberIndex:  0.
	self changed: #memberList.