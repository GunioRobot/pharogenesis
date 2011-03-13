acceptPhonyConnection

	| twins |

	twins _ LoopbackStringSocket newPair.
	self addClientFromConnection: twins first.
	(NetworkTerminalMorph new connection: twins second) inspect "openInWorld".
