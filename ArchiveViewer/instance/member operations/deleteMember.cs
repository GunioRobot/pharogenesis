deleteMember
	self canDeleteMember ifFalse: [ ^self ].
	archive removeMember: self selectedMember.
	self memberIndex:  0.
	self changed: #memberList.
