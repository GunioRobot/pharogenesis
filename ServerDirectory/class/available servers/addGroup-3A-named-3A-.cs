addGroup: serverArray named: nameString
	| groupAssn |
	serverArray do: [:server | server removeFromGroup].
	groupAssn _ nameString -> serverArray asArray copy.
	serverArray do: [:server | server group: groupAssn].