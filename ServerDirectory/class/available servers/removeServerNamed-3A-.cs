removeServerNamed: nameString
	(self serverNamed: nameString) removeFromGroup.
	Servers removeKey: nameString