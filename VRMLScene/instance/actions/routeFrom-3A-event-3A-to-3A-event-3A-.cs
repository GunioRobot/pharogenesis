routeFrom: fromNode event: outEventName to: toNode event: inEventName
	| source target |
	sourceNodes ifNil:[
		sourceNodes _ IdentitySet new.
		targetNodes _ IdentitySet new].
	source _ self definedNode: fromNode.
	target _ self definedNode: toNode.
	sourceNodes add: source.
	targetNodes add: target.
	source
		when: outEventName asSymbol
		send: (self eventSelectorFor: inEventName)
		to: target