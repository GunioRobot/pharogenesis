allClassNames
	^ (items 
		select: [:ea | ea isOrganizationDefinition not] 
		thenCollect: [:ea | ea className]) asSet.
