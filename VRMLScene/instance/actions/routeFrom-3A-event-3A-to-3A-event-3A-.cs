routeFrom: fromNode event: outEventName to: toNode event: inEventName
	(self definedNode: fromNode)
		when: outEventName asSymbol
		send: (self eventSelectorFor: inEventName)
		to: (self definedNode: toNode).