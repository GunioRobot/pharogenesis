callExternalPrimitive: mapIndex
	| entry |
	entry _ (mappedPluginEntries at: mapIndex).
	^(entry at: 1) perform: (entry at: 2).