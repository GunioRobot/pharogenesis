svcCreateCategory
	^ (OBService action: (MessageSend receiver: self selector: #createCategory:))
		condition: [:req | req requestNode hasOrganization];
		label: 'create category...'