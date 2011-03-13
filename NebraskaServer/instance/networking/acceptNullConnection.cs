acceptNullConnection

	| twins |

	twins _ LoopbackStringSocket newPair.
	self addClientFromConnection: twins first.
	(NullTerminalMorph new connection: twins second) openInWorld.
